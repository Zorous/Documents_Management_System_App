// src/app/sign-in.tsx
import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, Alert, Image } from 'react-native';
import { gql, useMutation } from '@apollo/client';
import { Link, useRouter } from 'expo-router';
import { SIGN_IN } from '@/queries/authQueries';
import { useAuth } from '@/AuthContext'; // Import AuthContext

const SignIn = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const router = useRouter();
  const { login } = useAuth(); // Use login function from AuthContext

  const [signIn, { loading }] = useMutation(SIGN_IN, {
    onCompleted: (data) => {
      login(data.signIn.token); // Call login to store token
      router.push('/(app)/Dashboard'); // Redirect to Dashboard after sign-in
    },
    onError: (error) => {
      Alert.alert("Sign-In Error", error.message);
    },
  });

  const handleSignIn = () => {
    signIn({ variables: { email, password } });
  };

  return (
    <View className="flex-1 justify-center items-center p-4 bg-gray-100">
      <Image
        source={{ uri: "https://ttline.atlassian.net/s/-50n9c3/b/8/998de07b2005665a20afd413ffeccdf6/_/jira-logo-scaled.png" }}
        className="mb-8 w-60 h-10"
      />
      <Text className="text-2xl font-bold mb-6">Log into your account</Text>
      <TextInput
        placeholder="Email"
        value={email}
        onChangeText={setEmail}
        className="border border-gray-300 rounded p-3 mb-4 w-full max-w-md shadow"
        autoCapitalize="none"
      />
      <TextInput
        placeholder="Password"
        value={password}
        onChangeText={setPassword}
        secureTextEntry
        className="border border-gray-300 rounded p-3 mb-4 w-full max-w-md shadow"
      />
      <TouchableOpacity
        onPress={handleSignIn}
        className={`bg-blue-500 p-3 rounded mb-5 w-full max-w-md items-center ${loading ? 'opacity-50' : ''}`}
        disabled={loading}
      >
        <Text className="text-white font-bold">{loading ? 'Signing In...' : 'Sign In'}</Text>
      </TouchableOpacity>

      <Link href="/SignUp" className="mt-4">
        <Text className="text-blue-500">Don't have an account? Sign Up</Text>
      </Link>
    </View>
  );
};

export default SignIn;
