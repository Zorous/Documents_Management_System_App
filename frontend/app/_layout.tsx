// RootLayout.tsx (or your main app component)
import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import TabLayout from "@/app/(tabs)/_layout"; // Assuming TabLayout is your tab navigator
import DocumentDetails from "@/components/screens/DocumentDetails";
import NotFoundScreen from "./+not-found";

const Stack = createNativeStackNavigator();

export default function Layout() {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen 
          name="Tabs" 
          component={TabLayout} 
          options={{ headerShown: false }} 
        />
        <Stack.Screen 
          name="NotFound" 
          component={NotFoundScreen} // Assuming you have a NotFound component
          options={{ title: "Not Found" }} 
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
}