import React from 'react';
import { View, Text, TouchableOpacity, StyleSheet, Image } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { COLORS } from '../../constants/Colors';
import { SIZES, FONTS } from '../../constants/theme';

type HeaderProps = {
  greeting: string;
  username: string;
  onProfilePress: () => void;
  onMenuPress : () => void;
};

export const Header: React.FC<HeaderProps> = ({ greeting, username, onProfilePress }) => (
  <View style={styles.header}>
    <View>
      <Text style={styles.greeting}>{greeting},</Text>
      <Text style={styles.username}>{username}</Text>
    </View>
    <TouchableOpacity onPress={onProfilePress}>
      <Image
        source={{ uri: 'https://randomuser.me/api/portraits/men/1.jpg' }}
        style={styles.avatar}
      />
    </TouchableOpacity>
  </View>
);

const styles = StyleSheet.create({
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: SIZES.padding,
    backgroundColor: COLORS.white,
    borderBottomLeftRadius: SIZES.radius,
    borderBottomRightRadius: SIZES.radius,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    elevation: 5,
  },
  greeting: {
    ...FONTS.h3,
    color: COLORS.textLight,
  },
  username: {
    ...FONTS.h2,
    color: COLORS.text,
  },
  avatar: {
    width: SIZES.width * 0.03,
    height: SIZES.width * 0.03,
    borderRadius: (SIZES.width * 0.12) / 2,
  },
});