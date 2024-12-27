import axios from 'axios';

const API_URL = 'https://localhost:7118/api/courses/';

class CourseService {
  async getPaginatedCourses(pageNumber, pageSize) {
    const response = await axios.get(`${API_URL}?pageNumber=${pageNumber}&pageSize=${pageSize}`);
    console.log(response);
    return response.data.data;
  }

  getCourseById(courseId) {
    return axios.get(`${API_URL}${courseId}`);
  }

  createCourse(courseData) {
    return axios.post(API_URL, courseData);
  }

  updateCourse(courseId, courseData) {
    return axios.put(`${API_URL}${courseId}`, courseData);
  }

  deleteCourse(courseId) {
    return axios.delete(`${API_URL}${courseId}`);
  }
}

export default new CourseService();