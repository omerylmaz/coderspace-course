import { BrowserRouter, Route, Routes } from "react-router-dom";
import { AuthProvider } from "./context/AuthContext";
import { CartProvider } from "./context/CartContext";
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

export default function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <CartProvider>
          <Navbar />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/register" element={<Register />} />
            <Route path="/login" element={<Login />} />
            <Route path="/product/:id" element={<CourseDetail />} />

            <Route path="/cart" element={ <ProtectedRoute> <Cart /></ProtectedRoute>}/>
            <Route path="/profile" element={ <ProtectedRoute> <UserDetail /> </ProtectedRoute>}/>
            <Route path="/payment" element={ <ProtectedRoute> <PaymentPage /> </ProtectedRoute>}/>
          </Routes>
          <Footer />
        </CartProvider>
      </BrowserRouter>
    </AuthProvider>
  );
}
