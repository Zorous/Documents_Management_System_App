import { Feather } from '@expo/vector-icons';

//export type FeatherIconName = React.ComponentProps<typeof Feather>['name'];
export type FeatherIconName = keyof typeof Feather.glyphMap;

export type MenuItem = {
  icon: FeatherIconName;
  label: string;
  onPress: () => void;
};

export type Document = {
  id: string;
  title: string;
  date: string;
};