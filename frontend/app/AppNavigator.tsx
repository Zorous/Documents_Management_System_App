import React, { useEffect, useState } from 'react';
import { Dimensions } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createDrawerNavigator } from '@react-navigation/drawer';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { Sidebar } from '@/components/layout/Sidebar';
import TabLayout from "./(tabs)/_layout"

const Drawer = createDrawerNavigator();
const Tab = createBottomTabNavigator();

const AppNavigator = () => {
  const [isSmallScreen, setIsSmallScreen] = useState(false);

  useEffect(() => {
    const updateLayout = () => {
      const { width } = Dimensions.get('window');
      setIsSmallScreen(width <= 768);
    };

    const subscription = Dimensions.addEventListener('change', updateLayout);
    updateLayout(); // Initial check

    return () => subscription?.remove();
  }, []);

  return (
    <NavigationContainer>
      {isSmallScreen ? (
        <TabLayout /> // Your tab layout for small screens
      ) : (
        <Drawer.Navigator>
          <Drawer.Screen name="Home" component={Sidebar} />
          {/* Add other drawer screens here */}
        </Drawer.Navigator>
      )}
    </NavigationContainer>
  );
};

export default AppNavigator;
