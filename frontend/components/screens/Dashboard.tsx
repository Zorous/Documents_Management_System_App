import React from 'react';
import { View, ScrollView, StyleSheet } from 'react-native';
import { Sidebar } from '../layout/Sidebar';
import { Header } from '../layout/Header';
import { QuickStats } from '../dashboard/QuickStats';
import { RecentDocuments } from '../dashboard/RecentDocuments';
import { QuickActions } from '../dashboard/QuickActions';
import { Colors } from '../../constants/Colors';

const recentDocuments = [
  { id: '1', title: 'Q2 Financial Report', date: '2023-06-15' },
  { id: '2', title: 'Product Roadmap', date: '2023-06-10' },
  { id: '3', title: 'Marketing Strategy', date: '2023-06-05' },
];

export const Dashboard: React.FC = () => (
  <View style={styles.container}>
    <Sidebar />
    <View style={styles.mainContent}>
      <Header />
      <ScrollView style={styles.dashboardContent}>
        <QuickStats />
        <RecentDocuments documents={recentDocuments} />
        <QuickActions />
      </ScrollView>
    </View>
  </View>
);

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'row',
    backgroundColor: '#f0f0f0',
  },
  mainContent: {
    flex: 1,
    backgroundColor: Colors.background,
  },
  dashboardContent: {
    padding: 20,
  },
});