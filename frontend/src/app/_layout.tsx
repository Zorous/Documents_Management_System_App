// src/Layout.tsx
import { ApolloProvider } from "@apollo/client";
import "../global.css";
import { Stack } from "expo-router";
import { AuthProvider } from "@/AuthContext";
import client from "@/apolloClient";
import ProtectedRoute from "@/ProtectedRoute";

export default function Layout() {
  return (
    <ApolloProvider client={client}>
      <AuthProvider>
        <Stack screenOptions={{ headerShown: false }}>
          <Stack.Screen name="SignIn" />
          <Stack.Screen name="SignUp" />
          <ProtectedRoute>
            <Stack.Screen name="(app)" options={{ headerShown: false }} />
          </ProtectedRoute>
          <Stack.Screen name="+not-found" options={{ headerShown: false }} />
        </Stack>
      </AuthProvider>
    </ApolloProvider>
  );
}
