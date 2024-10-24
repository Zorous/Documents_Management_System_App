// HomeScreen.tsx
import React from 'react';
import { View, Text } from 'react-native';
import { Link } from 'expo-router';

const HomeScreen = () => {
  return (
    <View className="flex-1 justify-center items-center bg-gray-100">
      <Text className="text-2xl font-bold mb-6">Welcome to Our App!</Text>
      <Link href="/SignIn" className="mb-4">
        <Text className=" text-blue-400 px-4 py-2">Sign In</Text>
      </Link>
      <Link href="/SignUp">
        <Text className=" text-blue-400 px-4 py-2">Sign Up</Text>
      </Link>
      <Link href="/home" className='mt-4'>
        <Text className=" text-blue-400 px-4 py-2">test connectivity</Text>
      </Link>
    </View>
  );
};

export default HomeScreen;
