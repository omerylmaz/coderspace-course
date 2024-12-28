import axios from 'axios';
import { api } from '../interceptors/axiosInterceptor';

const API_URL = 'https://localhost:7118/api/courses/';

class CourseService {
  async getPaginatedCourses(pageNumber, pageSize) {
    const response = await api.get(`courses/?pageNumber=${pageNumber}&pageSize=${pageSize}`);
    return response.data.data;
  }

  async getPaginatedCoursesByFiltering(pageNumber, pageSize, searchTerm, category) {
    const params = {
      pageNumber,
      pageSize,
      name: searchTerm || undefined,
      categoryName: category || undefined,
    };
  
    const response = await api.get(`courses/filtering`, { params });
    return response.data.data;
  }

  async getCourseById(courseId) {
    const response = await api.get(`courses/${courseId}`);
    console.log(response);
    return response.data;
  }

  async getPaidCourses(pageNumber, pageSize) {
    const response = await api.get(`courses/user/paid?pageNumber=${pageNumber}&pageSize=${pageSize}`);
    return response.data;
  }

  createCourse(courseData) {
    return api.post("courses/", courseData);
  }

  updateCourse(courseId, courseData) {
    return api.put(`courses/${courseId}`, courseData);
  }

  deleteCourse(courseId) {
    return api.delete(`courses/${courseId}`);
  }


}

export default new CourseService();