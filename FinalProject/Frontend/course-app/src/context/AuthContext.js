import authService from "../services/authService";

export const login = async (userData) => {
    const result = await authService.login(userData);
    const { accessToken, refreshToken } = result.token;

    localStorage.setItem("accessToken", accessToken);
    localStorage.setItem("refreshToken", refreshToken);

    return true;
};

export const logout = () => {
  localStorage.removeItem("accessToken");
  localStorage.removeItem("refreshToken");
};

export const isAuthenticated = () => {
  const token = localStorage.getItem("accessToken");
  console.log(token);
  return !!token;
};
