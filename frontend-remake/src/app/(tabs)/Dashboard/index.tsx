import { Dashboard } from '../../../../components/screens';
import { Tabs } from 'expo-router';
import React from 'react';
import { View } from 'react-native';

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


export default Index;
