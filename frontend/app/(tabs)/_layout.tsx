// @ts-nocheck
import React, { useEffect, useState, useRef } from "react";
import { View, Dimensions, Animated } from "react-native";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { Feather } from "@expo/vector-icons";
import { Dashboard } from "@/components/screens/Dashboard";
import Documents from "@/components/screens/Documents";
import { Sidebar } from "@/components/layout/Sidebar";
import { Header } from "@/components/layout/Header";
import { menuItems } from "@/constants/menuItems";
import { useAuth } from '../AuthContext'; // Use your Auth context here
import Login from "@/components/screens/Login";

const Tab = createBottomTabNavigator();

const TabbarLayout = () => {
  const { isLoggedIn } = useAuth(); // Get auth state
  const [screenWidth, setScreenWidth] = useState(Dimensions.get("window").width);
  const [isSmallScreen, setIsSmallScreen] = useState(screenWidth < 768);
  const [currentScreen, setCurrentScreen] = useState("Home");
  const [lastScreen, setLastScreen] = useState("Home");

  const tabBarOpacity = useRef(new Animated.Value(isSmallScreen ? 1 : 0)).current;

  useEffect(() => {
    const handleResize = () => {
      const newScreenWidth = Dimensions.get("window").width;
      setScreenWidth(newScreenWidth);
      const isNowSmallScreen = newScreenWidth < 768;
      setIsSmallScreen(isNowSmallScreen);

      Animated.timing(tabBarOpacity, {
        toValue: isNowSmallScreen ? 1 : 0,
        duration: 300,
        useNativeDriver: true,
      }).start();

      if (isNowSmallScreen) {
        setCurrentScreen(lastScreen);
      }
    };

    const subscription = Dimensions.addEventListener("change", handleResize);
    return () => {
      subscription?.remove();
    };
  }, [lastScreen, tabBarOpacity]);

  const handleScreenChange = (screen) => {
    setCurrentScreen(screen);
    setLastScreen(screen);
  };

  // Only show the content if the user is logged in
  if (!isLoggedIn) {
    return <Login />; // Redirect to login if not authenticated
  }

  // Wrapper component to conditionally render the current screen
  const CurrentScreenComponent = () => {
    switch (currentScreen) {
      case "Home":
        return <Dashboard />;
      case "Documents":
        return <Documents />;
      default:
        return null;
    }
  };

  return (
    <>
      {isSmallScreen ? (
        <Animated.View style={{ flex: 1, opacity: tabBarOpacity }}>
          <Header />
          <Tab.Navigator>
            {menuItems.map((item, index) => (
              <Tab.Screen
                key={index}
                name={item.label}
                icon={item.icon}
                options={{
                  headerShown: false,
                  tabBarIcon: ({ color, size }) => (
                    <Feather name={item.icon} size={size} color={color} />
                  ),
                }}
                listeners={{
                  tabPress: () => {
                    handleScreenChange(item.label);
                  },
                }}
              >
                {() => {
                  switch (item.label) {
                    case "Home":
                      return <Dashboard />;
                    case "Documents":
                      return <Documents />;
                    default:
                      return null;
                  }
                }}
              </Tab.Screen>
            ))}
          </Tab.Navigator>
        </Animated.View>
      ) : (
        <View style={{ flexDirection: "row", flex: 1 }}>
          <Sidebar
            menuItems={menuItems.map((item) => ({
              ...item,
              onPress: () => handleScreenChange(item.label),
            }))}
          />
          <View style={{ flex: 1 }}>
            <Header />
            <CurrentScreenComponent />
          </View>
        </View>
      )}
    </>
  );
};

export default TabbarLayout;
