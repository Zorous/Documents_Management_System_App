//@ts-nocheck
import React, { createContext, useState, useContext, ReactNode } from 'react';
import userData from "../data/data.json"

// Define an interface for user data
export interface User {
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

// Define the shape of your auth context
interface AuthContextType {
  isLoggedIn: boolean;
  user: User | null; // User can be null if not logged in
  login: (credentials: { email: string; password: string }) => void; // Specify the type of userData
  logout: () => void;
}

// Create the Auth Context with a default value
const defaultAuthContext: AuthContextType = {
  isLoggedIn: false,
  user: null,
  login: () => {}, // Default function for login
  logout: () => {}, // Default function for logout
};

const AuthContext = createContext<AuthContextType>(defaultAuthContext);

// Custom provider to wrap the app
export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [user, setUser] = useState<User | null>(null); // Store user information

 const login = (credentials: { email: string; password: string }) => {
  console.log("Attempting to login with:", credentials); // Log attempt

    // Check if userData exists and find the user
    const user = userData.find(
      (user) => user.email === credentials.email && user.passwordHash === credentials.password
    );

    if (user) {
      setUser(user); 
      setIsLoggedIn(true); // Set logged-in state
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

// Custom hook to use the Auth Context
export const useAuth = () => {
  return useContext(AuthContext);
};
