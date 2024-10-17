import { Dashboard } from '@/components/screens';
import { Tabs } from 'expo-router';
import React from 'react';
import { StyleSheet, View } from 'react-native';

const Index = () => {
    return (
        <><Tabs  screenOptions={{
            headerShown: false,
            headerTitle: "Dashboard"
          }}>
        </Tabs>

        <Dashboard />
        </>
    );
}

const styles = StyleSheet.create({})

export default Index;
