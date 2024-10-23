// src/app/sign-up.tsx
import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, Alert } from 'react-native';
import { gql, useMutation } from '@apollo/client';
import { Link, useRouter } from 'expo-router';

const SIGN_UP = gql`
  mutation SignUp($email: String!, $password: String!, $name: String!) {
    signUp(email: $email, password: $password, name: $name) {
      token
      user {
        id
        name
      }
    }
  }
`;

const SignUp = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [name, setName] = useState('');
  const router = useRouter();

  const [signUp, { loading }] = useMutation(SIGN_UP, {
    onCompleted: (data) => {
      // Handle successful sign-up (store token, navigate, etc.)
      console.log(data);
      Alert.alert("Welcome!", `Hello ${data.signUp.user.name}`);
      router.push('/(app)/Dashboard'); // Navigate to Dashboard after sign-up
    },
    onError: (error) => {
      // Handle error
      Alert.alert("Sign-Up Error", error.message);
    },
  });

  const handleSignUp = () => {
    signUp({ variables: { email, password, name } });
  };

  return (
    <View className="flex-1 justify-center items-center p-4 bg-gray-100">
      <Text className="text-xl font-bold mb-4">Sign Up</Text>
      <TextInput
        placeholder="Name"
        value={name}
        onChangeText={setName}
        className="border border-gray-300 rounded p-2 mb-4 w-full"
      />
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
        onPress={handleSignUp}
        className="bg-blue-500 p-2 rounded w-full items-center"
        disabled={loading}
      >
        <Text className="text-white font-bold">{loading ? 'Signing Up...' : 'Sign Up'}</Text>
      </TouchableOpacity>
      <Link href="/sign-in" className="mt-4">
        <Text className="text-blue-500">Already have an account? Sign In</Text>
      </Link>
    </View>
  );
};

export default SignUp;
