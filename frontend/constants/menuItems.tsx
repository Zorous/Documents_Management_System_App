import { MenuItem } from "@/types/MenuItem";


export const menuItems: MenuItem[] = [
  { icon: 'home', label: 'Dashbaord', onPress: (navigation) => navigation.navigate('Dashboard') },
  { icon: 'file-text', label: 'Documents', onPress: (navigation) => navigation.navigate('Documents') },
  { icon: 'folder', label: 'Categories', onPress: (navigation) => navigation.navigate('Categories') },
  { icon: 'users', label: 'Teams', onPress: (navigation) => navigation.navigate('Teams') },
  { icon: 'settings', label: 'Settings', onPress: (navigation) => navigation.navigate('Settings') },
];
