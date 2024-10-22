import React from 'react';
import { View, StyleSheet } from 'react-native';
import { StatItem } from '../common/StatItem';
import { COLORS } from '../../constants/Colors';
import { SIZES } from '../../constants/theme';

export const QuickStats: React.FC = () => (
  <View style={styles.container}>
    <StatItem label="Total Documents" value={152} />
    <StatItem label="Categories" value={8} />
    <StatItem label="Team Members" value={37} />
  </View>
);

const styles = StyleSheet.create({
  container: {
    flexDirection: 'row',
    justifyContent: 'space-around',
    backgroundColor: COLORS.white,
    borderRadius: SIZES.radius,
    padding: SIZES.padding,
    marginHorizontal: SIZES.padding,
    marginTop: SIZES.padding,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    elevation: 5,
  },
});