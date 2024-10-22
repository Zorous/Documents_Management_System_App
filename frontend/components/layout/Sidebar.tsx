//@ts-nocheck
import React from 'react';
import { View, Text, ScrollView } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { COLORS } from '../../constants/Colors';
import { SIZES, FONTS } from '../../constants/theme';
import { menuItems } from '@/constants/menuItems';
import { Link } from 'expo-router';

export const Sidebar = () => {
  return (
    <View className="bg-blue w-40 h-full"> {/* Ensure you have bg-blue defined */}
      <View className="items-center mb-8">
        <Text className="text-white text-lg">DocManager</Text>
      </View>
      <ScrollView className="flex-1">
        {menuItems.map((item) => (
          <Link
            key={item.name}
            href={item.href}
            className="flex flex-row items-center py-4 px-6"
          >
            <Feather name={item.icon} size={24} color={COLORS.white} />
            <Text className={`${FONTS.body3} text-white ml-4`}>
              {item.label}
            </Text>
          </Link>
        ))}
      </ScrollView>
    </View>
  );
};
