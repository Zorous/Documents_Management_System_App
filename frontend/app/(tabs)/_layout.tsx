import React from 'react';
import { Tabs } from 'expo-router';
import { TabBarIcon } from '@/components/navigation/TabBarIcon';
import { menuItems } from '@/constants/menuItems'; // Ensure this path is correct
import { useColorScheme } from '@/hooks/useColorScheme';

export default function TabLayout() {
  const colorScheme = useColorScheme();

  return (
    <Tabs
      screenOptions={{
        headerShown: false,
      }}>
      {menuItems.map((item) => (
        <Tabs.Screen
          key={item.label}
          name={item.label.toLowerCase()} // Use lowercase for consistent naming
          options={{
            title: item.label,
            tabBarIcon: ({ color, focused }) => (
              <TabBarIcon
                name={focused ? item.icon : `${item.icon}-outline`}
                color={color}
              />
            ),
          }}
        />
      ))}
    </Tabs>
  );
}
