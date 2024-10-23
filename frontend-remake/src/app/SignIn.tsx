// src/app/sign-in.tsx
import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, Alert } from 'react-native';
import { gql, useMutation } from '@apollo/client';
import { Link, useRouter } from 'expo-router';

const SIGN_IN = gql`
  mutation SignIn($email: String!, $password: String!) {
    signIn(email: $email, password: $password) {
      token
      user {
        id
        name
      }
    }
  }
`;

const SignIn = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const router = useRouter();

  const [signIn, { loading }] = useMutation(SIGN_IN, {
    onCompleted: (data) => {
      // Store the token in local storage or state management
      console.log(data);
      // Redirect to home/dashboard after sign-in
      router.push('/(app)/Dashboard'); // going to Dashboard after sign-in
    },
    onError: (error) => {
      // Handle error
      Alert.alert("Sign-In Error", error.message);
    },
  });

  const handleSignIn = () => {
    signIn({ variables: { email, password } });
  };

  return (
    <View className="flex-1 justify-center items-center p-4 bg-gray-100">
      <Text className="text-xl font-bold mb-4">Sign In</Text>
      <TextInput
        placeholder="Email"
        value={email}
        onChangeText={setEmail}
        className="border border-gray-300 rounded p-2 mb-4 w-full"
      />
      <TextInput
        placeholder="Password"
        value={password}
        onChangeText={setPassword}
        secureTextEntry
        className="border border-gray-300 rounded p-2 mb-4 w-full"
      />
      <TouchableOpacity
        onPress={handleSignIn}
        className="bg-blue-500 p-2 rounded w-full items-center"
        disabled={loading}
      >
        <Text className="text-white font-bold">{loading ? 'Signing In...' : 'Sign In'}</Text>
      </TouchableOpacity>
      <Link href="/sign-up" className="mt-4">
        <Text className="text-blue-500">Don't have an account? Sign Up</Text>
      </Link>
    </View>
  );
};

export default SignIn;
