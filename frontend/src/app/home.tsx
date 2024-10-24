// src/app/index.tsx
import React from 'react';
import { View, Text, FlatList, ActivityIndicator, Image } from 'react-native';
import { ApolloProvider, useQuery } from '@apollo/client';
import { GET_USERS } from '../queries/userQueries';
import client from '@/apolloClient';

const placeholderAvatar = 'https://www.shutterstock.com/image-vector/vector-flat-illustration-grayscale-avatar-600nw-2281862025.jpg'; // Placeholder avatar URL

const HomeScreen = () => {
  const { loading, error, data } = useQuery(GET_USERS);

  // Connection status message
  let connectionStatus;
  if (loading) {
    connectionStatus = <ActivityIndicator size="large" color="#0000ff" />;
  } else if (error) {
    connectionStatus = <Text className="text-red-500 text-lg my-2">Error: {error.message}</Text>;
  } else {
    connectionStatus = <Text className="text-green-500 text-lg my-2 text-center">🎉 Connected 🎉</Text>;
  }

  // Show loading indicator while fetching
  if (loading) return <ActivityIndicator size="large" color="#0000ff" />;

  return (
    <View className="flex-1 p-4 bg-gray-100">
      <Text className="text-2xl font-bold mb-2 text-center">Users List</Text>
      {connectionStatus}
      <FlatList
        data={data.users} // Adjust based on your GraphQL response structure
        keyExtractor={(item) => item.userId.toString()} // Ensure userId is unique
        renderItem={({ item }) => (
          <View className="flex-row items-center p-2 border-b border-gray-300">
            <Image 
              source={{ uri: placeholderAvatar }} 
              className="w-12 h-12 rounded-full mr-3" // Avatar style
            />
            <View>
              <Text className="text-lg font-semibold">User Name: {item.userName}</Text>
              <Text className="text-gray-600">Email: {item.email}</Text>
            </View>
          </View>
        )}
      />
    </View>
  );
};

const App = () => {
  return (
    <ApolloProvider client={client}>
      <HomeScreen />
    </ApolloProvider>
  );
};

export default App;
