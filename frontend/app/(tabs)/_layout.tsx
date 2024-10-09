// app/tabs/_layout.tsx
import React from "react";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
//import TabHome from "./index";  // Assuming you have a home screen in the tabs folder
import { Dashboard } from "@/components/screens/Dashboard";
import Documents from "@/components/screens/Documents";

const Tab = createBottomTabNavigator();

export default function TabLayout() {
  return (
    <Tab.Navigator>
      <Tab.Screen 
        name="Home" 
        component={Dashboard} 
        options={{ headerShown: false }} 
      />
      <Tab.Screen 
        name="Documents" 
        component={Documents} 
        options={{ title: "Documents" }} 
      />
    </Tab.Navigator>
  );
}
