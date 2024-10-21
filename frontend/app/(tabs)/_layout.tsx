import React, { useEffect, useState } from "react";
import { View, Dimensions, StyleSheet } from "react-native";
import { Tabs } from "expo-router";
import { useColorScheme } from "@/hooks/useColorScheme";
import { Header } from "@/components/layout/Header";
import { Sidebar } from "@/components/layout/Sidebar"; // Adjust this import as necessary

export default function TabLayout() {
  const colorScheme = useColorScheme();
  const [isSmallScreen, setIsSmallScreen] = useState(false);

  useEffect(() => {
    const updateLayout = () => {
      const { width } = Dimensions.get("window");
      setIsSmallScreen(width < 768); // Adjust the threshold as needed
    };

    const subscription = Dimensions.addEventListener("change", updateLayout);
    updateLayout(); // Initial check

    return () => {
      subscription?.remove(); // Clean up the subscription
    };
  }, []);

  return (
    <View style={styles.container}>
     <Header />
      <View style={styles.mainContent}>
        {isSmallScreen ? (
          <>
          <Tabs
            screenOptions={{
              headerShown: false,
            }}
          >
            <Tabs.Screen
              name="index"
              options={{
                title: "Dashboard",
              }}

            />
            <Tabs.Screen name="about" options={{ title: "About" }} />
          </Tabs></>
        ) : (
          <View style={styles.largescreen_layout}>
          <View style={styles.sidebarContainer}>
            <Sidebar />
            <View style={styles.tabsContainer}>
              <Tabs
                screenOptions={{
                  headerShown: false,
                  headerStyle:{
                    display: "none"                  }
                }}
              >
                <Tabs.Screen
                  name="index"
                  options={{
                    title: "Dashboard",
                  }}
                />
                <Tabs.Screen name="about" options={{ title: "About" }} />
              </Tabs>
            </View>
          </View>
          </View>
        )}
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  mainContent: {
    flex: 1,
    flexDirection: "row",
  },
  sidebarContainer: {
    flexDirection: "row",
    flex: 1,
  },
  tabsContainer: {
    flex: 1,
  },
  largescreen_layout:{
    flex:1,
    flexDirection:"row"
  }
});
