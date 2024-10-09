// @ts-nocheck
import * as React from "react";
import { useEffect, useState, useRef } from "react";

import { Text, StyleSheet, View, Dimensions, Animated } from "react-native";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import { Tabs } from "expo-router";
import { Dashboard } from "@/components/screens/Dashboard";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";

import Documents from "@/components/screens/Documents";
import { Sidebar } from "@/components/layout/Sidebar";
import { menuItems } from "@/constants/menuItems";
import { Feather } from "@expo/vector-icons";

const Tab = createBottomTabNavigator();

const Stack = createNativeStackNavigator();

const TabbarLayout = () => {
  const [screenWidth, setScreenWidth] = useState(
    Dimensions.get("window").width
  );
  const [isSmallScreen, setIsSmallScreen] = useState(screenWidth < 768);
  const [currentScreen, setCurrentScreen] = useState("Home");
  const [lastScreen, setLastScreen] = useState("Home");

  const tabBarOpacity = useRef(
    new Animated.Value(isSmallScreen ? 1 : 0)
  ).current;

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
          <Tab.Navigator>
            {menuItems.map((item, index) => (
              <Tab.Screen
                key={index}
                name={item.label} // Assuming each item.label is unique for the tab name
                icon={item.icon}
                options={{
                  headerShown: false,
                  tabBarIcon: ({ color, size }) => (
                    <Feather name={item.icon} size={size} color={color} />
                  ),
                }}
                listeners={{
                  tabPress: () => {
                    handleScreenChange(item.label); // Handle screen change based on item label
                  },
                }}
              >
                {() => {
                  // Here, you can conditionally return the component based on the current screen
                  switch (item.label) {
                    case "Home":
                      return <Dashboard />;
                    case "Documents":
                      return <Documents />;
                    // Add other cases as needed
                    default:
                      return null; // Return null or a default component if no match
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
              onPress: () => handleScreenChange(item.label), // Set onPress to change screen
            }))}
          />
          <View style={{ flex: 1 }}>
            <CurrentScreenComponent />
          </View>
        </View>
      )}
    </>
  );
};
const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: "row",
    backgroundColor: "#f0f0f0",
  },
  sidebar: {
    width: 220,
    backgroundColor: "#3498db",
    padding: 20,
  },
  logo: {
    marginBottom: 30,
  },
  logoText: {
    color: "#ffffff",
    fontSize: 24,
    fontWeight: "bold",
  },
  menuItem: {
    flexDirection: "row",
    alignItems: "center",
    marginBottom: 20,
  },
  menuText: {
    color: "#ffffff",
    marginLeft: 10,
    fontSize: 16,
  },
  mainContent: {
    flex: 1,
    backgroundColor: "#ffffff",
  },
  header: {
    flexDirection: "row",
    justifyContent: "space-between",
    alignItems: "center",
    padding: 20,
    borderBottomWidth: 1,
    borderBottomColor: "#e0e0e0",
  },
  headerTitle: {
    fontSize: 24,
    fontWeight: "bold",
    color: "#333333",
  },
  profileButton: {
    padding: 10,
  },
  dashboardContent: {
    padding: 20,
  },
  quickStats: {
    flexDirection: "row",
    justifyContent: "space-between",
    marginBottom: 30,
  },
  statItem: {
    backgroundColor: "#f9f9f9",
    borderRadius: 10,
    padding: 20,
    alignItems: "center",
    flex: 1,
    marginHorizontal: 5,
  },
  statNumber: {
    fontSize: 24,
    fontWeight: "bold",
    color: "#3498db",
    marginBottom: 5,
  },
  statLabel: {
    fontSize: 14,
    color: "#666666",
  },
  sectionTitle: {
    fontSize: 18,
    fontWeight: "bold",
    marginBottom: 15,
    color: "#333333",
  },
  recentDocs: {
    marginBottom: 30,
  },
  recentDocItem: {
    flexDirection: "row",
    alignItems: "center",
    backgroundColor: "#f9f9f9",
    borderRadius: 10,
    padding: 15,
    marginBottom: 10,
  },
  recentDocInfo: {
    marginLeft: 15,
  },
  recentDocTitle: {
    fontSize: 16,
    fontWeight: "bold",
    color: "#333333",
  },
  recentDocDate: {
    fontSize: 14,
    color: "#666666",
  },
  quickActions: {
    marginBottom: 30,
  },
  actionButtons: {
    flexDirection: "row",
    justifyContent: "space-between",
  },
  actionButton: {
    backgroundColor: "#f1c40f",
    borderRadius: 10,
    padding: 15,
    alignItems: "center",
    flex: 1,
    marginHorizontal: 5,
  },
  actionButtonText: {
    color: "#ffffff",
    marginTop: 5,
    fontWeight: "bold",
  },
});

export default TabbarLayout;
