
import { NavigationProp } from '@react-navigation/native';

export type MenuItem = {
    icon: string;  // Change to lowercase 'string'
    label: string; // Change to lowercase 'string'
    onPress: (navigation: NavigationProp<any>) => void; // Update here
};
