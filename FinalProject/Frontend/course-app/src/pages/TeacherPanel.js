import React, { useEffect, useState } from 'react';
import courseService from '../services/courseService';
import { Link } from 'react-router-dom';
import alertify from 'alertifyjs';

export default function TeacherPanel() {
  const [courses, setCourses] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const handleDeleteCourse = async (id) => {
    alertify.confirm(
      'Delete Course',
      'Are you sure you want to delete this course?',
      async () => {
        try {
          await courseService.deleteCourse(id);
          setCourses(courses.filter((course) => course.id !== id));
          alertify.success('Course deleted successfully');
        } catch (error) {
          alertify.error(error.message);
        }
      },
      () => {
        alertify.message('Delete action canceled');
      }
    );
  };

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        const data = await courseService.getPaginatedTeacherCourses(1, 6);
        setCourses(data.courses.items);
      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    fetchCourses();
  }, []);

  if (loading) return <div>Loading...</div>;
  if (error) return <div className="alert alert-danger">{error}</div>;

  return (
    <div className="container mt-4">
      <h1>My Courses</h1>
      <Link to="/teacher/courses/create" className="btn btn-primary mb-3">
        Create New Course
      </Link>
      <div className="row">
        {courses.map((course) => (
          <div key={course.id} className="col-md-4">
            <div className="card mb-4 shadow-sm">
              <img src={course.imageUrl} className="card-img-top" alt={course.name} />
              <div className="card-body">
                <h5 className="card-title">{course.name}</h5>
                <p className="card-text">{course.description}</p>
                <p className="card-text"><strong>Price:</strong> {course.price}₺</p>
                <div className="d-flex justify-content-between">
                  <Link to={`/teacher/courses/edit/${course.id}`} className="btn btn-warning">
                    Edit Course
                  </Link>
                  <button
                    className="btn btn-danger"
                    onClick={() => handleDeleteCourse(course.id)}
                  >
                    Delete Course
                  </button>
                </div>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
