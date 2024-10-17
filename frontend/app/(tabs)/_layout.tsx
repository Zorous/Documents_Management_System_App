import React from "react";
import { Tabs } from "expo-router";
import { TabBarIcon } from "@/components/navigation/TabBarIcon";
import { menuItems } from "@/constants/menuItems"; // Ensure this path is correct
import { useColorScheme } from "@/hooks/useColorScheme";
import { Header } from "@/components/layout/Header";

export default function TabLayout() {
  const colorScheme = useColorScheme();

  return (
    <>
      <Header />
      <Tabs
        screenOptions={{
          headerShown: false,
        }}
      ></Tabs>
    </>
  );
}
