import React from 'react';
import { View, Text, StyleSheet } from 'react-native';
import { Colors } from '../../constants/Colors';

type StatItemProps = {
  number: number;
  label: string;
};

export const StatItem: React.FC<StatItemProps> = ({ number, label }) => (
  <View style={styles.statItem}>
    <Text style={styles.statNumber}>{number}</Text>
    <Text style={styles.statLabel}>{label}</Text>
  </View>
);

const styles = StyleSheet.create({
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
    color: Colors.primary,
    marginBottom: 5,
  },
  statLabel: {
    fontSize: 14,
    color: Colors.textLight,
  },
});