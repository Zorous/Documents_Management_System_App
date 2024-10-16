import React from 'react';
import { View, Text, TouchableOpacity, StyleSheet, ScrollView } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { COLORS } from '../../constants/Colors';
import { SIZES, FONTS } from '../../constants/theme';
import { menuItems } from '@/constants/menuItems';


export const Sidebar = ({ navigation }) => {

  return (
    <View style={styles.sidebar}>
      <View style={styles.logoContainer}>
        <Text style={styles.logoText}>DocManager</Text>
      </View>
      <ScrollView style={styles.menuContainer}>
        {menuItems.map((item, index) => (
          <TouchableOpacity
            key={index}
            style={styles.menuItem}
            onPress={() => item.onPress(navigation)}
            accessibilityRole="button"
            accessibilityLabel={item.label}
          >
            <Feather name={item.icon} size={24} color={COLORS.white} />
            <Text style={styles.menuText}>{item.label}</Text>
          </TouchableOpacity>
        ))}
      </ScrollView>
    </View>
  );
};

const styles = StyleSheet.create({
  sidebar: {
    width: SIZES.width * 0.7,
    maxWidth: 300,
    backgroundColor: COLORS.primary,
    paddingTop: SIZES.padding * 2,
  },
  logoContainer: {
    alignItems: 'center',
    marginBottom: SIZES.padding * 2,
  },
  logoText: {
    ...FONTS.h1,
    color: COLORS.white,
  },
  menuContainer: {
    flex: 1,
  },
  menuItem: {
    flexDirection: 'row',
    alignItems: 'center',
    paddingVertical: SIZES.padding,
    paddingHorizontal: SIZES.padding * 1.5,
  },
  menuText: {
    ...FONTS.body3,
    color: COLORS.white,
    marginLeft: SIZES.padding,
  },
});