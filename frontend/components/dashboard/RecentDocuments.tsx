import React from 'react';
import { View, Text, StyleSheet } from 'react-native';
import { Feather } from '@expo/vector-icons';
import { Colors} from '../../constants/Colors';
import { Document } from '../../types';

type RecentDocumentProps = {
  document: Document;
};

const RecentDocument: React.FC<RecentDocumentProps> = ({ document }) => (
  <View style={styles.recentDocItem}>
    <Feather name="file" size={24} color={Colors.primary} />
    <View style={styles.recentDocInfo}>
      <Text style={styles.recentDocTitle}>{document.title}</Text>
      <Text style={styles.recentDocDate}>{document.date}</Text>
    </View>
  </View>
);

type RecentDocumentsProps = {
  documents: Document[];
};

export const RecentDocuments: React.FC<RecentDocumentsProps> = ({ documents }) => (
  <View style={styles.recentDocs}>
    <Text style={styles.sectionTitle}>Recent Documents</Text>
    {documents.map((doc) => (
      <RecentDocument key={doc.id} document={doc} />
    ))}
  </View>
);

const styles = StyleSheet.create({
  recentDocs: {
    marginBottom: 30,
  },
  sectionTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 15,
    color: Colors.text,
  },
  recentDocItem: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: '#f9f9f9',
    borderRadius: 10,
    padding: 15,
    marginBottom: 10,
  },
  recentDocInfo: {
    marginLeft: 15,
  },
  recentDocTitle: {
    fontSize: 16,
    fontWeight: 'bold',
    color: Colors.text,
  },
  recentDocDate: {
    fontSize: 14,
    color: Colors.textLight,
  },
});