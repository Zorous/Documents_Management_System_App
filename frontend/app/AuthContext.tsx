//@ts-nocheck
import React, { createContext, useState, useContext, ReactNode } from 'react';
import userData from "../data/data.json";

interface User {
  userId: number;
  userName: string;
  profilePicture: string;
  email: string;
  passwordHash: string;
  createdAt: Date;
  userRoles: [];
  createdDocuments: [];
  documentAccesses: [];
  tenantDepartmentUsers: [];
}

interface AuthContextType {
  isLoggedIn: boolean;
  user: User | null;
  login: (credentials: { email: string; password: string }) => void;
  logout: () => void;
}

const defaultAuthContext: AuthContextType = {
  isLoggedIn: false,
  user: null,
  login: () => {},
  logout: () => {},
};

const AuthContext = createContext<AuthContextType>(defaultAuthContext);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [user, setUser] = useState<User | null>(null);

  const login = (credentials: { email: string; password: string }) => {
    const foundUser = userData.find(
      (user) => user.email === credentials.email && user.passwordHash === credentials.password
    );

    if (foundUser) {
      setUser(foundUser);
      setIsLoggedIn(true);
      alert('Login Successful');
    } else {
      alert('Invalid username or password.');
    }
  };

  const logout = () => {
    setIsLoggedIn(false);
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ isLoggedIn, user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  return useContext(AuthContext);
};
