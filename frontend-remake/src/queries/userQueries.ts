// src/queries/userQueries.ts
import { gql } from '@apollo/client';

export const GET_USERS = gql`
  query GetUsers {
    users {
      userId
      userName
      email
    }
  }
`;
