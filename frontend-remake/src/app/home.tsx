// src/app/index.tsx
import React from 'react';
import { ApolloProvider } from '@apollo/client';
import { Stack } from 'expo-router';
import client from '../apolloClient'; // Adjust the path as needed
import { View, Text, FlatList, ActivityIndicator } from 'react-native';
import { gql, useQuery } from '@apollo/client';

// Define your GraphQL query to get users
const GET_USERS = gql`
  query GetUsers {
    users {
      userId
      userName
      email
    }
  }
`;

const HomePage = () => {
  // Fetch users using Apollo's useQuery hook
  const { loading, error, data } = useQuery(GET_USERS);

  // Handle loading state
  if (loading) {
    return (
      <View className="flex-1 justify-center items-center bg-gray-100">
        <ActivityIndicator size="large" color="#0000ff" />
      </View>
    );
  }

  // Handle error state
  if (error) {
    return (
      <View className="flex-1 justify-center items-center bg-gray-100">
        <Text className="text-red-500">Error loading users</Text>
      </View>
    );
  }

  return (
    <View className="flex-1 p-4 bg-gray-100">
      <Text className="text-2xl font-bold mb-4">User List</Text>
      <FlatList
        data={data.users}
        keyExtractor={(item) => item.userId.toString()}
        renderItem={({ item }) => (
          <View className="p-4 bg-white mb-3 rounded-lg shadow">
            <Text className="text-lg font-semibold">{item.userName}</Text>
            <Text className="text-sm text-gray-500">{item.email}</Text>
          </View>
        )}
      />
    </View>
  );
};

// Main app component
export default function App() {
  return (
    <ApolloProvider client={client}>
        <Stack>
          <Stack.Screen name="index" />
        </Stack>
    </ApolloProvider>
  );
}
