import React from 'react';
import { View, Text, TouchableOpacity, StyleSheet } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { Colors } from '../../constants/Colors';

export const Header: React.FC = () => (
  <View style={styles.header}>
    <Text style={styles.headerTitle}>Dashboard</Text>
    <TouchableOpacity style={styles.profileButton}>
      <Feather name="user" size={24} color={Colors.primary} />
    </TouchableOpacity>
  </View>
);

const styles = StyleSheet.create({
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: 20,
    borderBottomWidth: 1,
    borderBottomColor: Colors.border,
  },
  headerTitle: {
    fontSize: 24,
    fontWeight: 'bold',
    color: Colors.text,
  },
  profileButton: {
    padding: 10,
  },
});