import { Feather } from '@expo/vector-icons';

export type FeatherIconName = React.ComponentProps<typeof Feather>['name'];

export type MenuItem = {
  icon: FeatherIconName;
  label: string;
};

export type Document = {
  id: string;
  title: string;
  date: string;
};