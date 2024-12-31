import { Link } from "react-router-dom";
import { useAuth } from '../context/AuthContext';
import { useNavigate } from "react-router-dom";
import { getUserRole } from "../utils/jwtDecoder";

export default function Navbar() {
  const navigate = useNavigate();
  const userRole = getUserRole();
  const { user, logout, isAuthenticated } = useAuth();

  function handleLogout() {
    logout();
    navigate("/");
    console.log("Logout");
  }

  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-dark sticky-top">
      <div className="container">
        <Link className="navbar-brand fw-bold" to="/">E-Course</Link>
        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
        >
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav ms-auto">
            <li className="nav-item">
              <Link className="nav-link" to="/">Home</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/cart">Cart</Link>
            </li>
            {isAuthenticated ? (
              <>
                {userRole === "Teacher" && (
                  <li className="nav-item">
                    <Link className="nav-link" to="/teacher">Teacher Panel</Link>
                  </li>
                )}
                <li className="nav-item">
                  <Link className="nav-link" to="/profile">My Profile</Link>
                </li>
                <li className="nav-item">
                  <button className="btn btn-danger" onClick={handleLogout}>Logout</button>
                </li>
              </>
            ) : (
              <>
                <li className="nav-item">
                  <Link className="nav-link" to="/login">Login</Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/register">Register</Link>
                </li>
              </>
            )}
          </ul>
        </div>
      </div>
    </nav>
  );
}
