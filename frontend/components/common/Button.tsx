import React from 'react';
import { TouchableOpacity, Text, StyleSheet } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { Colors } from '../../constants/Colors';
import { FeatherIconName } from '../../types';

type ButtonProps = {
  icon: FeatherIconName;
  label: string;
  onPress: () => void;
};

export const Button: React.FC<ButtonProps> = ({ icon, label, onPress }) => (
  <TouchableOpacity style={styles.button} onPress={onPress}>
    <Feather name={icon} size={24} color={Colors.background} />
    <Text style={styles.buttonText}>{label}</Text>
  </TouchableOpacity>
);

const styles = StyleSheet.create({
  button: {
    backgroundColor: Colors.secondary,
    borderRadius: 10,
    padding: 15,
    alignItems: 'center',
    flex: 1,
    marginHorizontal: 5,
  },
  buttonText: {
    color: Colors.background,
    marginTop: 5,
    fontWeight: 'bold',
  },
});