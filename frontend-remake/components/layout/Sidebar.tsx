import React from 'react';
import { View, Text, TouchableOpacity, ScrollView } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { menuItems } from 'constants/menuItems'; // Adjust the path as needed
import { Link } from 'expo-router';

const SideBar = () => {
  return (
    <View className="xl:w-[15%] sm:w-[15%] h-full bg-blue-500 p-4 shadow-lg">
        <Text className='text-3xl text-white mb-16'>DMS</Text>
      <ScrollView>
        {menuItems.map((item) => (
          <Link
            key={item.name}
            className="flex flex-row items-center p-3 mb-2 rounded-lg hover:bg-blue-600"
            href={item.href}
          >
            <Feather name={item.icon} size={24} color="white" />
            <Text className="text-white text-lg ml-3">{item.label}</Text>
          </Link>
        ))}
      </ScrollView>
    </View>
  );
};

export default SideBar;
