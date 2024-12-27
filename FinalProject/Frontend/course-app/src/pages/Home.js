import { useEffect, useState } from "react";
import ProductCart from "../components/ProductCart";
import courseService from "../services/courseService";

export default function Home() {
  const [products, setProducts] = useState([]);
  const [categories, setCategories] = useState([]);
  const [category, setCategory] = useState("All");
  const [searchTerm, setSearchTerm] = useState("");

  // Pagination state
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize, setPageSize] = useState(6);
  const [totalCount, setTotalCount] = useState(0);

  useEffect(() => {
    fetchProducts(pageNumber, pageSize, searchTerm, category);
  }, [pageNumber, pageSize, searchTerm, category]);

  const fetchProducts = (page, size, term, cat) => {
    courseService.getPaginatedCourses(page, size, term, cat).then((res) => {
      const fetchedProducts = res.courses.items;
      setProducts(fetchedProducts);
      setTotalCount(res.courses.totalCount);

      const uniqueCategories = [
        ...new Set(fetchedProducts.map((product) => product.categoryName)),
      ];
      setCategories(uniqueCategories);
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
            {categories.map((cat, index) => (
              <option key={index} value={cat}>
                {cat}
              </option>
            ))}
          </select>
        </div>
      </div>

      <div className="row">
        {products.map((product) => (
          <ProductCart key={product.id} product={product}></ProductCart>
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
    </div>
  );
}
