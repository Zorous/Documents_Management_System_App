import React from 'react';
import { View, Text, StyleSheet } from 'react-native';
import { COLORS } from '../../constants/Colors';
import { SIZES, FONTS } from '../../constants/theme';

type StatItemProps = {
  label: string;
  value: string | number;
};

export function StatItem({ label, value }: StatItemProps) {
  return (
    <View style={styles.statItem}>
      <Text style={styles.statValue}>{value}</Text>
      <Text style={styles.statLabel}>{label}</Text>
    </View>
  );
}


const styles = StyleSheet.create({
  statItem: {
    alignItems: 'center',
    padding: SIZES.base,
  },
  statValue: {
    ...FONTS.h2,
    color: COLORS.primary,
    marginBottom: SIZES.base / 2,
  },
  statLabel: {
    ...FONTS.body4,
    color: COLORS.textLight,
  },
});