import axios from 'axios';
import authService from '../services/authService';
import { useAuth } from '../context/AuthContext';

const API_URL = 'https://localhost:7118/api/';

const api = axios.create({
  baseURL: API_URL,
  timeout: 10000,
});

const setupInterceptors = (authContext) => {
  api.interceptors.request.use(
    (config) => {
      const token = authContext.authData?.accessToken;
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
      console.log(error);
      if (error.response) {
        const { status, data } = error.response;

        if (data && data.errors && data.errors.length > 0) {
          const errorsArray = data.errors;
          const combinedErrors = errorsArray.join('\n');
          return Promise.reject(new Error(combinedErrors));
        }

        if (data && data.detail) {
          return Promise.reject(new Error(data.detail));
        }

        switch (status) {
          case 401:
            try {
              const refreshToken = authContext.authData?.refreshToken;
              if (refreshToken) {
                const result = await authService.refreshToken(refreshToken);
                authContext.login(result);
                error.config.headers['Authorization'] = `Bearer ${result.accessToken}`;
                return api(error.config);
              }
            } catch (refreshError) {
              authContext.logout();
              window.location.href = '/login';
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
      }
      else{
        return Promise.reject(new Error('Server is unavailable'));

      }

    }
  );
};

export { api, setupInterceptors };
