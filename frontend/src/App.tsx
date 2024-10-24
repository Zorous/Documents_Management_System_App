// src/App.tsx
import React from 'react';
import { ApolloProvider } from '@apollo/client';
import client from './apolloClient';
import { AuthProvider } from './AuthContext';
import { Stack } from 'expo-router';

const App = () => {
  return (
    <ApolloProvider client={client}>
      <AuthProvider>
        <Stack />
      </AuthProvider>
    </ApolloProvider>
  );
};

export default App;
