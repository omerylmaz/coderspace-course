import { BrowserRouter, Route, Routes } from "react-router-dom";
// import { CartProvider } from "./context/CartContext";
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Cart from "./pages/Cart";
import CourseDetail from "./pages/CourseDetail";
import UserDetail from "./pages/UserDetail";
import ProtectedRoute from "./components/ProtectedRoute";
import PaymentPage from "./pages/Payment";
import TeacherPanel from "./pages/TeacherPanel";
import CreateCourse from "./pages/CreateCourse";
import EditCourse from "./pages/EditCourse";
import 'alertifyjs/build/css/alertify.css';

export default function App() {
  return (
    <BrowserRouter>
      {/* <CartProvider> */}
        <Navbar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/register" element={<Register />} />
          <Route path="/login" element={<Login />} />
          <Route path="/product/:id" element={<CourseDetail />} />

          <Route
            path="/cart"
            element={
              <ProtectedRoute requiredRoles={["User", "Teacher"]}>
                <Cart />
              </ProtectedRoute>
            }
          />
          <Route
            path="/profile"
            element={
              <ProtectedRoute requiredRoles={["User", "Teacher"]}>
                <UserDetail />
              </ProtectedRoute>
            }
          />
          <Route
            path="/payment"
            element={
              <ProtectedRoute requiredRoles={["User", "Teacher"]}>
                <PaymentPage />
              </ProtectedRoute>
            }
          />

          <Route
            path="/teacher"
            element={
              <ProtectedRoute requiredRoles={["Teacher"]}>
                <TeacherPanel />
              </ProtectedRoute>
            }
          />
          <Route
            path="/teacher/courses/create"
            element={
              <ProtectedRoute requiredRoles={["Teacher"]}>
                <CreateCourse />
              </ProtectedRoute>
            }
          />
          <Route
            path="/teacher/courses/edit/:id"
            element={
              <ProtectedRoute requiredRoles={["Teacher"]}>
                <EditCourse />
              </ProtectedRoute>
            }
          />
        </Routes>
        <Footer />
      {/* </CartProvider> */}
    </BrowserRouter>
  );
}
