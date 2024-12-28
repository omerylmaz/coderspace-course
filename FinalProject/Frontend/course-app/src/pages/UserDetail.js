import { useEffect, useState } from "react";
import ProductCart from "../components/ProductCart";
import Spinner from "../components/LoadingSpinner";
import authService from "../services/authService";
import courseService from "../services/courseService";

export default function UserDetail() {
  const [userDetails, setUserDetails] = useState(null);
  const [courses, setCourses] = useState([]);
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize, setPageSize] = useState(6);
  const [totalCount, setTotalCount] = useState(0);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUserDetails = async () => {
      try {
        const userResponse = await authService.getUserDetails();
        setUserDetails(userResponse);
      } catch (err) {
        setError(err.message);
      }
    };

    fetchUserDetails();
  }, []);

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        setIsLoading(true);
        const coursesResponse = await courseService.getPaidCourses(
          pageNumber,
          pageSize
        );
        setCourses(coursesResponse.courses.items);
        setTotalCount(coursesResponse.courses.totalCount);
      } catch (err) {
        setError(err.message);
      } finally {
        setIsLoading(false);
      }
    };

    fetchCourses();
  }, [pageNumber, pageSize]);

  const totalPages = Math.ceil(totalCount / pageSize);

  if (error) {
    return <div className="text-danger">Error: {error}</div>;
  }

  return (
    <div className="container mt-4">
      <h1 className="text-center mb-4">User Details</h1>

      {userDetails && (
        <div className="card shadow p-4 mb-4">
          <h2>{userDetails.fullName}</h2>
          <p>
            <strong>Username:</strong> {userDetails.userName}
          </p>
          <p>
            <strong>Email:</strong> {userDetails.email}
          </p>
          <p>
            <strong>Phone Number:</strong> {userDetails.phoneNumber}
          </p>
        </div>
      )}

      <h2 className="text-center mb-4">Purchased Courses</h2>
      {isLoading ? (
        <div className="d-flex justify-content-center my-4">
          <Spinner />
        </div>
      ) : (
        <>
          <div className="row">
            {courses.map((course) => (
              <ProductCart key={course.id} course={course} />
            ))}
          </div>

          {totalPages > 1 && (
            <nav>
              <ul className="pagination justify-content-center mt-4">
                {[...Array(totalPages).keys()].map((number) => (
                  <li
                    key={number + 1}
                    className={`page-item ${
                      pageNumber === number + 1 ? "active" : ""
                    }`}
                  >
                    <button
                      onClick={() => setPageNumber(number + 1)}
                      className="page-link"
                    >
                      {number + 1}
                    </button>
                  </li>
                ))}
              </ul>
            </nav>
          )}
        </>
      )}
    </div>
  );
}
