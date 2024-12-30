import { api } from '../interceptors/axiosInterceptor';

class OrderService {
  async createOrder(courseId) {
    const response = await api.post('orders', { courseId });
    return response.data.data;
  }
}

export default new OrderService();