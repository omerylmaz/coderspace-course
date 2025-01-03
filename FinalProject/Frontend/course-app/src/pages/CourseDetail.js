import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import courseService from "../services/courseService";
import Spinner from "../components/LoadingSpinner";
import CourseContent from "../components/CourseContent";
import orderService from "../services/orderService";
import { useAuth } from "../context/AuthContext";
import alertify from 'alertifyjs';

export default function CourseDetail() {
  const { id } = useParams();
  const navigate = useNavigate();
  const { isAuthenticated } = useAuth();
  const [course, setCourse] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [totalDuration, setTotalDuration] = useState(0);

  useEffect(() => {
    courseService.getCourseById(id).then((res) => {
      setCourse(res.data);

      const durationInMinutes = res.data.contents?.reduce((total, content) => {
        const [hours, minutes] = content.duration.split(":").map(Number);
        return total + hours * 60 + minutes;
      }, 0);

      setTotalDuration(durationInMinutes);
      setIsLoading(false);
    });
  }, [id]);

  const handleBuyCourse = async () => {
    if (!isAuthenticated) {
      navigate("/login");
      return;
    }
    try {
      await orderService.createOrder(course.id);
      navigate("/payment", { state: { course } });
    } catch (error) {
      alertify.error(error.message);
    }
  };

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
                className="btn btn-success btn-lg mt-3"
                onClick={handleBuyCourse}
              >
                Buy Course
              </button>
            </div>
          </div>
        </div>
      </div>

      <div className="mt-5">
        <h3>Course Content</h3>
        <p>
          {course.contents.length} lectures • {Math.floor(totalDuration / 60)}h{" "}
          {totalDuration % 60}m total length
        </p>
        {course.contents && course.contents.length > 0 ? (
          <CourseContent contents={course.contents} />
        ) : (
          <p>No course content.</p>
        )}
      </div>
    </div>
  );
}
