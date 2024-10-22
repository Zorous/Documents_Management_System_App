import React from 'react';
import { View, Text, StyleSheet, FlatList } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { COLORS } from '../../constants/Colors';
import { SIZES, FONTS } from '../../constants/theme';

type Document = {
  id: string;
  title: string;
  date: string;
};

type RecentDocumentsProps = {
  documents: Document[];
};

const DocumentItem: React.FC<{ document: Document }> = ({ document }) => (
  <View style={styles.documentItem}>
    <Feather name="file-text" size={24} color={COLORS.primary} />
    <View style={styles.documentInfo}>
      <Text style={styles.documentTitle}>{document.title}</Text>
      <Text style={styles.documentDate}>{document.date}</Text>
    </View>
  </View>
);

export const RecentDocuments: React.FC<RecentDocumentsProps> = ({ documents }) => (
  <View style={styles.container}>
    <Text style={styles.title}>Recent Documents</Text>
    <FlatList
      data={documents}
      renderItem={({ item }) => <DocumentItem document={item} />}
      keyExtractor={(item) => item.id}
    />
  </View>
);

const styles = StyleSheet.create({
  container: {
    backgroundColor: COLORS.white,
    borderRadius: SIZES.radius,
    padding: SIZES.padding,
    marginHorizontal: SIZES.padding,
    marginTop: SIZES.padding,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    elevation: 5,
  },
  title: {
    ...FONTS.h2,
    color: COLORS.text,
    marginBottom: SIZES.padding,
  },
  documentItem: {
    flexDirection: 'row',
    alignItems: 'center',
    paddingVertical: SIZES.base,
  },
  documentInfo: {
    marginLeft: SIZES.base,
  },
  documentTitle: {
    ...FONTS.body3,
    color: COLORS.text,
  },
  documentDate: {
    ...FONTS.body4,
    color: COLORS.textLight,
  },
});