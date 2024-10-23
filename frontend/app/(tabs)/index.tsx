import { Tabs } from 'expo-router';
import Index from './Dashboard';



export default function HomeScreen() {
  return (
    <>
    <Tabs  screenOptions={{
            headerShown: false,
            headerTitle: "Dashboard"
          }}>
    <Index />
    </Tabs>
    </>
  );
}

