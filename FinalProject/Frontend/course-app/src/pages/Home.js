import { useEffect, useState } from "react";
import ProductCart from "../components/ProductCart";
import courseService from "../services/courseService";
import categoryService from "../services/categoryService";
import Spinner from '../components/LoadingSpinner';

export default function Home() {
  const [courses, setCourses] = useState([]);
  const [categories, setCategories] = useState([]);
  const [category, setCategory] = useState("All");
  const [searchTerm, setSearchTerm] = useState("");

  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize, setPageSize] = useState(6);
  const [totalCount, setTotalCount] = useState(0);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    fetchCategories();
    fetchCourses(pageNumber, pageSize, searchTerm, category);
  }, [pageNumber, pageSize, searchTerm, category]);

  const fetchCourses = (page, size, term, cat) => {
    setIsLoading(true);
    if (cat === "All") {
      cat = "";
    }

    courseService.getPaginatedCoursesByFiltering(page, size, term, cat).then((res) => {
      setCourses(res.courses.items);
      setTotalCount(res.courses.totalCount);
    }).catch((err) => {
      console.error("Error fetching courses:", err);
    }).finally(() => {
      setIsLoading(false);
    });
  };

  const fetchCategories = () => {
    categoryService.getAllCategories().then((res) => {
      setCategories(res.categories);
    });
  };

  const handleSearch = (e) => {
    setSearchTerm(e.target.value);
    setPageNumber(1);
  };

  const handleCategoryChange = (e) => {
    setCategory(e.target.value);
    setPageNumber(1);
  };

  const totalPages = Math.ceil(totalCount / pageSize);

  const pageNumbers = [...Array(totalPages).keys()].map((n) => n + 1);

  return (
    <div className="container mt-4">
      <h1 className="text-center mb-4">Top Products</h1>

      <div className="row mb-3">
        <div className="col-md-6">
          <input
            type="text"
            className="form-control"
            placeholder="Search product.."
            value={searchTerm}
            onChange={handleSearch}
          ></input>
        </div>
        <div className="col-md-6">
          <select
            className="form-select"
            value={category}
            onChange={handleCategoryChange}
          >
            <option value="All">All Categories</option>
            {categories.map((cat) => (
              <option key={cat.id} value={cat.name}>
                {cat.name}
              </option>
            ))}
          </select>
        </div>
      </div>

      {isLoading ? (
        <div className="d-flex justify-content-center my-4">
          <Spinner />
        </div>
      ) : (
        <>
          <div className="row">
            {courses.map((course) => (
              <ProductCart key={course.id} course={course}></ProductCart>
            ))}
          </div>

          {totalPages > 1 && (
            <nav>
              <ul className="pagination justify-content-center mt-4">
                {pageNumbers.map((number) => (
                  <li
                    key={number}
                    className={`page-item ${
                      pageNumber === number ? "active" : ""
                    }`}
                  >
                    <button
                      onClick={() => setPageNumber(number)}
                      className="page-link"
                    >
                      {number}
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
