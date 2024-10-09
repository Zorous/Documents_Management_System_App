import React, { useState, useEffect } from 'react';
import { View, ScrollView, StyleSheet, useWindowDimensions } from 'react-native';
import { Header } from '../layout/Header';
import { Sidebar } from '../layout/Sidebar';
import { QuickStats } from '../dashboard/QuickStats';
import { RecentDocuments } from '../dashboard/RecentDocuments';
import { COLORS } from '../../constants/Colors';
import { SIZES } from '../../constants/theme';
import { MenuItem, Document } from '../../types';
import { QuickActions } from '../dashboard/QuickActions';
import { NavigationProp } from '@react-navigation/native';


const recentDocuments: Document[] = [
  { id: '1', title: 'Q2 Financial Report', date: '2023-06-15' },
  { id: '2', title: 'Product Roadmap', date: '2023-06-10' },
  { id: '3', title: 'Marketing Strategy', date: '2023-06-05' },
];

const menuItems: MenuItem[] = [
  { icon: 'home', label: 'Dashboard', onPress: () => console.log('Dashboard pressed') },
  { icon: 'file-text', label: 'Documents', onPress: () => console.log('Documents pressed') },
  { icon: 'folder', label: 'Categories', onPress: () => console.log('Categories pressed') },
  { icon: 'users', label: 'Team', onPress: () => console.log('Team pressed') },
  { icon: 'settings', label: 'Settings', onPress: () => console.log('Settings pressed') },
];

export function Dashboard() { 
  const [greeting, setGreeting] = useState('');
  const [isSidebarVisible, setIsSidebarVisible] = useState(false);
  const { width } = useWindowDimensions();

  useEffect(() => {
    const updateGreeting = () => {
      const hour = new Date().getHours();
      if (hour < 12) setGreeting('Good morning');
      else if (hour < 18) setGreeting('Good afternoon');
      else setGreeting('Good evening');
    };

    updateGreeting();
    const interval = setInterval(updateGreeting, 60000); 

    return () => clearInterval(interval);
  }, []);

  useEffect(() => {
    setIsSidebarVisible(width > 768);
  }, [width]);

  return (
    <View style={styles.container}>
      <View style={styles.mainContent}>
        <Header 
          greeting={greeting} 
          username="John" 
          onProfilePress={() => {/* Navigate to profile */}}
          onMenuPress={() => setIsSidebarVisible(!isSidebarVisible)}
        />
        <ScrollView style={styles.content}>
          <QuickStats />
          <RecentDocuments documents={recentDocuments} />
          <QuickActions />
        </ScrollView>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'row',
    backgroundColor: COLORS.background,
  },
  mainContent: {
    flex: 1,
  },
  content: {
    flex: 1,
    paddingBottom: SIZES.padding,
  },
});
