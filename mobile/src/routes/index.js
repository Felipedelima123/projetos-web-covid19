import React from 'react';
import { ActivityIndicator, View } from 'react-native';
import { AppProvider } from '../contexts/AppContext';
import useAuth from '../contexts/AuthContext';
import AppStack from './AppStack';
import AuthStack from './AuthStack';
import styles from './styles';

function Routes() {
  const { signed, loading } = useAuth();

  if (signed) {
    return (
      <AppProvider>
        <AppStack />
      </AppProvider>
    );
  }

  if (loading) {
    return (
      <View style={styles.loadingContainer}>
        <ActivityIndicator size="large" />
      </View>
    );
  }

  return <AuthStack />;
}

export default Routes;
