import React from 'react';
import { View, StyleSheet } from 'react-native';
import { StatItem } from '../common/StatItem';

export const QuickStats: React.FC = () => (
  <View style={styles.quickStats}>
    <StatItem number={152} label="Total Documents" />
    <StatItem number={8} label="Categories" />
    <StatItem number={37} label="Team Members" />
  </View>
);

const styles = StyleSheet.create({
  quickStats: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginBottom: 30,
  },
});