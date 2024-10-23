// src/ProtectedRoute.tsx
import React from 'react';
import { Redirect } from 'expo-router';
import { useAuth } from './AuthContext';

const ProtectedRoute: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const { isAuthenticated } = useAuth();

  if (!isAuthenticated) {
    return <Redirect href="/sign-in" />;
  }

  return <>{children}</>;
};

export default ProtectedRoute;
