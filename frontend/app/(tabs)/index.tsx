import React from 'react';
import { View, Text, ScrollView, TouchableOpacity, StyleSheet, SafeAreaView } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { Dashboard } from '@/components/screens/Dashboard';

type MenuItem = {
  icon: keyof typeof Feather.glyphMap;
  label: string;
};

const menuItems: MenuItem[] = [
  { icon: 'home', label: 'Home' },
  { icon: 'file-text', label: 'Documents' },
  { icon: 'folder', label: 'Categories' },
  { icon: 'users', label: 'Teams' },
  { icon: 'settings', label: 'Settings' },
];

const RecentDocument: React.FC<{ title: string; date: string }> = ({ title, date }) => (
  <View style={styles.recentDocItem}>
    <Feather name="file" size={24} color="#3498db" />
    <View style={styles.recentDocInfo}>
      <Text style={styles.recentDocTitle}>{title}</Text>
      <Text style={styles.recentDocDate}>{date}</Text>
    </View>
  </View>
);

export default function index() {
  return (
    <SafeAreaView style={styles.container}>
      <Dashboard />
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'row',
    backgroundColor: '#f0f0f0',
  },
  sidebar: {
    width: 220,
    backgroundColor: '#3498db',
    padding: 20,
  },
  logo: {
    marginBottom: 30,
  },
  logoText: {
    color: '#ffffff',
    fontSize: 24,
    fontWeight: 'bold',
  },
  menuItem: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 20,
  },
  menuText: {
    color: '#ffffff',
    marginLeft: 10,
    fontSize: 16,
  },
  mainContent: {
    flex: 1,
    backgroundColor: '#ffffff',
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: 20,
    borderBottomWidth: 1,
    borderBottomColor: '#e0e0e0',
  },
  headerTitle: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#333333',
  },
  profileButton: {
    padding: 10,
  },
  dashboardContent: {
    padding: 20,
  },
  quickStats: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginBottom: 30,
  },
  statItem: {
    backgroundColor: '#f9f9f9',
    borderRadius: 10,
    padding: 20,
    alignItems: 'center',
    flex: 1,
    marginHorizontal: 5,
  },
  statNumber: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#3498db',
    marginBottom: 5,
  },
  statLabel: {
    fontSize: 14,
    color: '#666666',
  },
  sectionTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 15,
    color: '#333333',
  },
  recentDocs: {
    marginBottom: 30,
  },
  recentDocItem: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: '#f9f9f9',
    borderRadius: 10,
    padding: 15,
    marginBottom: 10,
  },
  recentDocInfo: {
    marginLeft: 15,
  },
  recentDocTitle: {
    fontSize: 16,
    fontWeight: 'bold',
    color: '#333333',
  },
  recentDocDate: {
    fontSize: 14,
    color: '#666666',
  },
  quickActions: {
    marginBottom: 30,
  },
  actionButtons: {
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
  actionButton: {
    backgroundColor: '#f1c40f',
    borderRadius: 10,
    padding: 15,
    alignItems: 'center',
    flex: 1,
    marginHorizontal: 5,
  },
  actionButtonText: {
    color: '#ffffff',
    marginTop: 5,
    fontWeight: 'bold',
  },
});