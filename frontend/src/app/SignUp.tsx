// src/app/sign-up.tsx
import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, Alert, Image } from 'react-native';
import { gql, useMutation } from '@apollo/client';
import { Link, useRouter } from 'expo-router';
import { SIGN_UP } from '@/queries/authQueries'; // Ensure you have a SIGN_UP query defined

const SignUp = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const router = useRouter();

  const [signUp, { loading }] = useMutation(SIGN_UP, {
    onCompleted: (data) => {
      // Handle successful sign-up
      console.log(data);
      // Redirect to home/dashboard after sign-up
      router.push('/(app)/Dashboard'); // going to Dashboard after sign-up
    },
    onError: (error) => {
      // Handle error
      Alert.alert("Sign-Up Error", error.message);
    },
  });

  const handleSignUp = () => {
    if (password !== confirmPassword) {
      Alert.alert("Error", "Passwords do not match.");
      return;
    }
    signUp({ variables: { email, password } });
  };

  return (
    <View className="flex-1 justify-center items-center p-4 bg-gray-100">
      <Image
        source={{ uri: "https://ttline.atlassian.net/s/-50n9c3/b/8/998de07b2005665a20afd413ffeccdf6/_/jira-logo-scaled.png" }}
        className="mb-8 w-60 h-10" // Responsive logo size
      />
      
      <Text className="text-2xl font-bold mb-6">Create a new account</Text>
      
      <TextInput
        placeholder="Email"
        value={email}
        onChangeText={setEmail}
        className="border border-gray-300 rounded p-3 mb-4 w-full max-w-md shadow" // Full width with max width
        autoCapitalize="none" // Prevent capitalization for email
      />
      <TextInput
        placeholder="Password"
        value={password}
        onChangeText={setPassword}
        secureTextEntry
        className="border border-gray-300 rounded p-3 mb-4 w-full max-w-md shadow" // Full width with max width
      />
      <TextInput
        placeholder="Confirm Password"
        value={confirmPassword}
        onChangeText={setConfirmPassword}
        secureTextEntry
        className="border border-gray-300 rounded p-3 mb-4 w-full max-w-md shadow" // Full width with max width
      />
      <TouchableOpacity
        onPress={handleSignUp}
        className={`bg-blue-500 p-3 rounded w-full max-w-md items-center ${loading ? 'opacity-50' : ''}`} // Full width with max width
        disabled={loading}
      >
        <Text className="text-white font-bold">{loading ? 'Signing Up...' : 'Sign Up'}</Text>
      </TouchableOpacity>

      <Link href="/SignIn" className="mt-4">
        <Text className="text-blue-500">Already have an account? Sign In</Text>
      </Link>
    </View>
  );
};

export default SignUp;
