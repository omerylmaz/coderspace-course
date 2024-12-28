import { BrowserRouter, Route, Routes } from "react-router-dom";
import {AuthProvider} from "./context/AuthContext";
import {CartProvider} from "./context/CartContext";
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import Home from "./pages/Home";
import PaymentForm from "./pages/PaymentForm";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Cart from "./pages/Cart";
import CourseDetail from "./pages/CourseDetail";
import UserDetail from "./pages/UserDetail";


export default function App(){
  return(
    <AuthProvider>
      <BrowserRouter>
        <CartProvider>
          <Navbar/>
          <Routes>
            <Route path="/" element={<Home/>}></Route>
            <Route path="/cart" element={<Cart/>}></Route>
            <Route path="/profile" element={<UserDetail/>}></Route>
            <Route path="/register" element={<Register />} />
            <Route path="/login" element={<Login/>}></Route>
            <Route path="/payment" element={<PaymentForm/>}></Route>
            <Route path="/product/:id" element={<CourseDetail/>}></Route>
          </Routes>
          <Footer></Footer>
        </CartProvider>
      </BrowserRouter>
    </AuthProvider>
  );
}