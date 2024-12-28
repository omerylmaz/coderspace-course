import { createContext, useState, useContext, useEffect } from "react";
import authService from "../services/authService";
import { setupInterceptors } from "../interceptors/axiosInterceptor";

const AuthContext = createContext();

export const useAuth = () => useContext(AuthContext);

export const AuthProvider = ({ children }) => {
  const [authData, setAuthData] = useState({
    accessToken: null,
    refreshToken: null,
  });

  const login = async (userData) => {
    const result = await authService.login(userData);
    const { accessToken, refreshToken } = result.token;

    setAuthData({
      accessToken,
      refreshToken,
    });
  };

  const logout = () => {
    setAuthData({
      accessToken: null,
      refreshToken: null,
    });
  };

  const isAuthenticated = !!authData.accessToken;

  useEffect(() => {
    setupInterceptors({ authData, login, logout });
  }, [authData]);

  return (
    <AuthContext.Provider value={{ authData, login, logout, isAuthenticated }}>
      {children}
    </AuthContext.Provider>
  );
};
