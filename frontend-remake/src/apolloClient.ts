// src/apolloClient.ts
import { ApolloClient, InMemoryCache, createHttpLink } from '@apollo/client';

// Use HTTP instead of HTTPS for local development
const httpLink = createHttpLink({
  uri: 'http://172.20.61.38:5000/api/proxy/graphql', // Updated to the proxy endpoint
});

const client = new ApolloClient({
  link: httpLink,
  cache: new InMemoryCache(),
});

export default client;
