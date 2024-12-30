import React, { useEffect, useState } from 'react';
import courseService from '../services/courseService';
import { Link } from 'react-router-dom';

export default function TeacherPanel() {
  const [courses, setCourses] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        // const data = await courseService.getTeacherCourses();
        // setCourses(data);
      } catch (err) {
        setError(err.message);
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
              <div className="card-body">
                <h5 className="card-title">{course.name}</h5>
                <p className="card-text">{course.description}</p>
                <p className="card-text"><strong>Price:</strong> {course.price}₺</p>
                <Link to={`/teacher/courses/edit/${course.id}`} className="btn btn-warning">
                  Edit Course
                </Link>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
