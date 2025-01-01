import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import courseService from '../services/courseService';
import Spinner from '../components/LoadingSpinner';
import orderService from "../services/orderService";
import { useAuth } from '../context/AuthContext';

export default function CourseDetail() {
  const { id } = useParams();
  const [course, setCourse] = useState(null);
    const { isAuthenticated } = useAuth();
  const [isLoading, setIsLoading] = useState(true);
  const navigate = useNavigate();

  const handleBuyCourse = async () => {
    if (!isAuthenticated) {
      navigate("/login");
      return;
    }
    await orderService.createOrder(course.id);
    navigate("/payment", { state: { course } });
  };

  useEffect(() => {
    setTimeout(() => {
      courseService.getCourseById(id).then((res) => {
        console.log(res.data);
        setCourse(res.data);
        setIsLoading(false);
      });
    }, 200);
  }, [id]);

  if (isLoading) {
    return <Spinner />;
  }
  return (
    <div className="container mt-4">
      <div className="card">
        <div className="row g-0">
          <div className="col-md-4">
            <img
              src={course.imageUrl}
              className="img-fluid rounded-start"
              alt={course.title}
            />
          </div>
          <div className="col-md-8">
            <div className="card-body">
              <h5 className="card-title">{course.title}</h5>
              <p className="card-text">{course.description}</p>
              <p className="card-text">
                <strong>Category:</strong> {course.categoryName}
              </p>
              <p className="card-text">
                <small className="text-muted">{course.price}₺</small>
              </p>
              <button
                className="btn btn-success btn-lg"
                onClick={handleBuyCourse}
              >
                Buy Course
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
