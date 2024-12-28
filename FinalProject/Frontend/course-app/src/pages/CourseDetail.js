import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { useCart } from '../context/CartContext';
import courseService from '../services/courseService';
import Spinner from '../components/LoadingSpinner';

export default function CourseDetail() {
  const { id } = useParams();
  const [course, setCourse] = useState(null);
  const { addToCart } = useCart();
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    setTimeout(() => {
      courseService.getCourseById(id).then((res) => {
        setCourse(res.data);
        setIsLoading(false);
      });
    }, 2000);
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
                <strong>Category:</strong> {course.categoryName || 'N/A'}
              </p>
              <p className="card-text">
                <small className="text-muted">{course.price}₺</small>
              </p>
              <button
                className="btn btn-success btn-lg"
                onClick={() => addToCart(course)}
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
