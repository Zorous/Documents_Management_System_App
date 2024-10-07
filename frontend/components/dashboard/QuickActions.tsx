import React from 'react';
import { View, Text, StyleSheet } from 'react-native';
import { Button } from '../common/Button';
import { Colors } from '../../constants/Colors';

export const QuickActions: React.FC = () => (
  <View style={styles.quickActions}>
    <Text style={styles.sectionTitle}>Quick Actions</Text>
    <View style={styles.actionButtons}>
      <Button icon="upload" label="Upload" onPress={() => {}} />
      <Button icon="file-plus" label="New Doc" onPress={() => {}} />
      <Button icon="share-2" label="Share" onPress={() => {}} />
    </View>
  </View>
);

const styles = StyleSheet.create({
  quickActions: {
    marginBottom: 30,
  },
  sectionTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 15,
    color: Colors.text,
  },
  actionButtons: {
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
});