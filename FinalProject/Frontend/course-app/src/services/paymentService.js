import { api } from '../interceptors/axiosInterceptor';

class PaymentService {
  async payCourse(paymentData) {
    try {
      const response = await api.post('payments', paymentData);
      return response.data;
    } catch (error) {
      throw error;
    }
  }
}

export default new PaymentService();
