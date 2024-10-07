const { Command } = require('commander');
import React from 'react';
import { View, Text, TouchableOpacity, StyleSheet } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { Colors } from '../../constants/Colors';
import { menuItems } from '../../constants/menuItems';
import { FeatherIconName } from '../../types';

export const Sidebar: React.FC = () => (
  <View style={styles.sidebar}>
    <View style={styles.logo}>
      <Text style={styles.logoText}>DocManager</Text>
    </View>
    {menuItems.map((item, index) => (
      <TouchableOpacity key={index} style={styles.menuItem}>
        <Feather name={item.icon} size={24} color={Colors.background} />
        <Text style={styles.menuText}>{item.label}</Text>
      </TouchableOpacity>
    ))}
  </View>
);

const styles = StyleSheet.create({
  sidebar: {
    width: 220,
    backgroundColor: Colors.primary,
    padding: 20,
  },
  logo: {
    marginBottom: 30,
  },
  logoText: {
    color: Colors.background,
    fontSize: 24,
    fontWeight: 'bold',
  },
  menuItem: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 20,
  },
  menuText: {
    color: Colors.background,
    marginLeft: 10,
    fontSize: 16,
  },
});