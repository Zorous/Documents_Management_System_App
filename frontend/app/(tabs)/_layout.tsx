import React, { useEffect, useState } from "react";
import { View, Dimensions, StyleSheet } from "react-native";
import { Tabs } from "expo-router";
import { useColorScheme } from "@/hooks/useColorScheme";
import { Header } from "@/components/layout/Header";
import { Sidebar } from "@/components/layout/Sidebar"; 

export default function TabLayout() {
  const colorScheme = useColorScheme();
  const [isSmallScreen, setIsSmallScreen] = useState(Dimensions.get("window").width < 768);

  useEffect(() => {
    const updateLayout = () => {
      setIsSmallScreen(Dimensions.get("window").width < 768);
    };

    const subscription = Dimensions.addEventListener("change", updateLayout);
    return () => subscription?.remove();
  }, []);

  return (
    <View style={styles.container}>
      <Header />
      <View style={styles.mainContent}>
        {isSmallScreen ? (
          <Tabs screenOptions={{ headerShown: false }}>
            <Tabs.Screen name="index" options={{ title: "Dashboard" }} />
            <Tabs.Screen name="about" options={{ title: "About" }} />
          </Tabs>
        ) : (
          <View style={styles.largerScreenLayout}>
            <Sidebar />
            <View style={styles.tabsContainer}>
              <Tabs screenOptions={{ headerShown: false }}>
                <Tabs.Screen name="index" options={{ title: "Dashboard" }} />
                <Tabs.Screen name="about" options={{ title: "About" }} />
              </Tabs>
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
  },
  largerScreenLayout: {
    flexDirection: "row",
    flex: 1,
  },
  tabsContainer: {
    flex: 1,
  },
});
