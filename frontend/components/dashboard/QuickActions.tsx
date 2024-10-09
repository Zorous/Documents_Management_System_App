import React from 'react';
import { View, Text, StyleSheet } from 'react-native';
import { Button } from '../common/Button';
import { COLORS } from '../../constants/Colors';
import { SIZES, FONTS } from '../../constants/theme';


export const QuickActions: React.FC = () => (
  <View style={styles.container}>
    <Text style={styles.sectionTitle}>Quick Actions</Text>
    <View style={styles.actionButtons}>
      <Button icon="upload" label="Upload" onPress={() => {}} />
      <Button icon="file-plus" label="New Doc" onPress={() => {}} />
      <Button icon="share-2" label="Share" onPress={() => {}} />
    </View>
  </View>
);

const styles = StyleSheet.create({
  container: {
    borderRadius: SIZES.radius,
    padding: SIZES.padding,
    marginHorizontal: SIZES.padding,
    marginTop: SIZES.padding,

  },
  quickActions: {
    marginBottom: 30,
  },
  sectionTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 15,
    color: COLORS.text,
  },
  actionButtons: {
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
});