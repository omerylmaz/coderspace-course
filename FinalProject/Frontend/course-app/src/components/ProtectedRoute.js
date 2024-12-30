import React from 'react';
import { getUserRole } from '../utils/jwtDecoder';

const ProtectedRoute = ({ children, requiredRole }) => {
  const userRoles = getUserRole();

  if (userRoles.length === 0) {
    return <div className="container mt-4 text-center"><h3>Unauthorized: Please log in to access.</h3></div>;
  }

  if (requiredRole && !userRoles.includes(requiredRole)) {
    return <div className="container mt-4 text-center"><h3>Unauthorized: You do not have permission to access.</h3></div>;
  }

  return children;
};

export default ProtectedRoute;
