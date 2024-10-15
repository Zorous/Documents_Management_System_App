import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { AuthProvider, useAuth } from './AuthContext';
import TabbarLayout from './(tabs)/_layout'; // Assuming the TabbarLayout is in a layout folder
import Login from '@/components/screens/Login';

const App = () => {
  return (
    <AuthProvider>
      <NavigationContainer>
        <AppNavigator />
      </NavigationContainer>
    </AuthProvider>
  );
};

// Conditionally render the layout or login screen based on auth state
const AppNavigator = () => {
  const { isLoggedIn } = useAuth();

  return isLoggedIn ? <TabbarLayout /> : <Login />;
};

export default App;
