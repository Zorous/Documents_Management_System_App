import React from 'react';
import { View, TouchableOpacity, Text } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { menuItems } from 'constants/menuItems'; // Adjust the path as needed
import { Link } from 'expo-router'; // Import Link for navigation

const BottomNavigation = () => {
  return (
    <View className="flex-row justify-around items-center bg-gray-300 p-2 shadow-md">
      {menuItems.map((item) => (
        <Link key={item.name} href={item.href} className="flex-1 items-center">
          <Feather name={item.icon} size={24} color="black" />
          <Text className="text-black text-xs">{item.label}</Text>
        </Link>
      ))}
    </View>
  );
};

export default BottomNavigation;
