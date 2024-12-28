import { api } from '../interceptors/axiosInterceptor';

class AuthService {
  async register(userData) {
    const response = await api.post('users/register', userData);
    return response.data.data;
  }

  async login(credentials) {
    const response = await api.post('users/login', credentials);
    return response.data.data;
  }

  async getUserDetails() {
    const response = await api.get('users/detail');
    console.log(response);
    return response.data.data;
  }
}

export default new AuthService();
