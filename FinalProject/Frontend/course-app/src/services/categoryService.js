import { api } from '../interceptors/axiosInterceptor';


const API_URL = 'https://localhost:7118/api/categories/';

class CategoryService {
  async getAllCategories() {
    const response = await api.get(`categories`);
    return response.data.data;
  }
}

export default new CategoryService();