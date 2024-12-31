import React, { useEffect, useState } from 'react';
import courseService from '../services/courseService';
import { Link } from 'react-router-dom';
import { Modal, Button } from 'react-bootstrap';
import 'alertifyjs/build/css/alertify.css';
import alertify from 'alertifyjs';

export default function TeacherPanel() {
  const [courses, setCourses] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [selectedCourseId, setSelectedCourseId] = useState(null);

  const handleShowModal = (id) => {
    setSelectedCourseId(id);
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
    setSelectedCourseId(null);
  };

  const handleDeleteCourse = async () => {
    try {
      await courseService.deleteCourse(selectedCourseId);
      setCourses(courses.filter((course) => course.id !== selectedCourseId));
      alertify.success('Course deleted successfully');
    } catch (err) {
      alertify.error(err.message);
    } finally {
      handleCloseModal();
    }
  };

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        const data = await courseService.getPaginatedTeacherCourses(1, 6);
        setCourses(data.courses.items);
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
                    onClick={() => handleShowModal(course.id)}
                  >
                    Delete Course
                  </button>
                </div>
              </div>
            </div>
          </div>
        ))}
      </div>

      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Delete Course</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Are you sure you want to delete this course?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseModal}>
            Cancel
          </Button>
          <Button variant="danger" onClick={handleDeleteCourse}>
            Delete
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}
