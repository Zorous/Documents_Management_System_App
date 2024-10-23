import "../global.css";
import { Slot, Stack } from "expo-router";

export default function Layout() {
  return (
    
    <Stack screenOptions={{ headerShown: false }}>
      <Stack.Screen name="(app)" options={{ headerShown: false }} />
      <Stack.Screen name="+not-found" options={{ headerShown: false }}  />
    </Stack>
);
}
