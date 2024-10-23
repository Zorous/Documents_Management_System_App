import React, { useEffect, useState } from 'react';
import { View, Dimensions } from 'react-native';
import { Link } from 'expo-router';
import {Header, SideBar, BottomNavigation} from "components/layout";


const MainLayout = () => {
  const [isSmallScreen, setIsSmallScreen] = useState(false);

  useEffect(() => {
    const updateLayout = () => {
      const { width } = Dimensions.get('window');
      setIsSmallScreen(width < 768); // Set breakpoint for small screens
    };

    const subscription = Dimensions.addEventListener('change', updateLayout);
    updateLayout(); // Initial check when component mounts

    return () => {
      subscription?.remove(); // Clean up the subscription when component unmounts
    };
  }, []);

  return (
    <View className="flex-1">
      <Header />

      {isSmallScreen ? (
        <View className="flex-1 justify-between bg-gray-100">
          {/* Your main content goes here */}
          <View className="flex-1">
            {/* Main Content Area */}
          </View>
          <BottomNavigation />
        </View>
      ) : (
        <View className="flex flex-row h-full">
          <SideBar />
          <View className="flex-1 bg-gray-100">
            {/* Your main content goes here */}
          </View>
        </View>
      )}
    </View>
  );
};

export default MainLayout;
