import { Link } from 'expo-router';
import { Image, StyleSheet, Platform, View, Text } from 'react-native';



export default function HomeScreen() {
  return (
    <>
    <View style={styles.stepContainer}>
      <Text></Text>
    </View>


    <Link href="/Dashboard">Dashbaord</Link>
    
    </>
  );
}

const styles = StyleSheet.create({
  titleContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 8,
  },
  stepContainer: {
    gap: 8,
    marginBottom: 8,
  },
  reactLogo: {
    height: 178,
    width: 290,
    bottom: 0,
    left: 0,
    position: 'absolute',
  },
});
