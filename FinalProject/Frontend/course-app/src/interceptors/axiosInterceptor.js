import axios from 'axios';
import authService from '../services/authService';

const API_URL = 'https://localhost:7118/api/';

const api = axios.create({
  baseURL: API_URL,
});

let refreshTokenPromise = null;

const getRefreshToken = () => {
  if (!refreshTokenPromise) {
    debugger;
    const refreshToken = localStorage.getItem('refreshToken');
    refreshTokenPromise = authService.refreshToken({refreshToken}).then((response) => {
        const { accessToken, refreshToken } = response.data.data; 
        localStorage.setItem('accessToken', accessToken);
        localStorage.setItem('refreshToken', refreshToken);
        refreshTokenPromise = null;
        return accessToken;
      })
      .catch((error) => {
        refreshTokenPromise = null;
        throw error;
      });
  }
  return refreshTokenPromise;
};

api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('accessToken');
    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

api.interceptors.response.use(
  (response) => response,
  async (error) => {
    const originalRequest = error.config;

    if (error.response) {
      const { status, data } = error.response;
      console.log(error.response);
      if (data && data.errors && data.errors.length > 0) {
        const errorsArray = data.errors;
        const combinedErrors = errorsArray.join('\n');
        return Promise.reject(new Error(combinedErrors));
      }

      if (data && data.detail) {
        console.log(data.detail);
        return Promise.reject(new Error(data.detail));
      }

      switch (status) {
        case 401: // Token yenile
          if (!originalRequest._retry) {
            originalRequest._retry = true;
            try {
              const token = await getRefreshToken();
              originalRequest.headers['Authorization'] = `Bearer ${token}`;
              return api(originalRequest);
            } catch (refreshError) {
              console.error('Refresh token failed:', refreshError);
              localStorage.removeItem('accessToken');
              localStorage.removeItem('refreshToken');
              window.location.href = '/login';
            }
          }
          break;

        case 403:
          return Promise.reject(new Error('You do not have permission to perform this action'));

        case 404:
          return Promise.reject(new Error('Method was not found'));

        case 500:
          return Promise.reject(new Error('Internal server error occurred'));

        default:
          return Promise.reject(new Error(data.message || 'An unknown error occurred'));
      }
    } else {
      return Promise.reject(new Error('Server is unavailable'));
    }
  }
);

export { api };
