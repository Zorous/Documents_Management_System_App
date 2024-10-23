// src/app/index.tsx
import React from 'react';
import { View, Text, FlatList, ActivityIndicator } from 'react-native';
import { ApolloProvider, useQuery } from '@apollo/client';
import { GET_USERS } from '../queries/userQueries';
import client from '@/apolloClient';

const HomeScreen = () => {
  const { loading, error, data } = useQuery(GET_USERS);

  if (loading) return <ActivityIndicator size="large" color="#0000ff" />;
  if (error) return <Text>Error: {error.message}</Text>;

  return (
    <View>
      <Text style={{ fontSize: 24, fontWeight: 'bold' }}>User List</Text>
      <FlatList
        data={data.users} // Adjust based on your GraphQL response structure
        keyExtractor={(item) => item.userId.toString()} // Ensure userId is unique
        renderItem={({ item }) => (
          <View style={{ padding: 10 }}>
            <Text>User Name: {item.userName}</Text>
            <Text>Email: {item.email}</Text>
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
