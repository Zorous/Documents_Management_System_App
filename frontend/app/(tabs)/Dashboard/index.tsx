import { Dashboard } from '@/components/screens';
import { Tabs } from 'expo-router';
import React from 'react';
import { StyleSheet, View } from 'react-native';

const Index = () => {
    return (
        <Tabs  screenOptions={{
            headerShown: true,
            headerTitle: "Dashboard"
          }}>
      
    <Dashboard />
        </Tabs>
    );
}

const styles = StyleSheet.create({})

export default Index;
