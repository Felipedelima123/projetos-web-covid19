import { NavigationContainer } from '@react-navigation/native';
import React from 'react';
import { AuthProvider } from './src/contexts/AuthContext';
import { Provider as PaperProvider } from 'react-native-paper';
import Routes from './src/routes';

export default function App() {
  return (
    <PaperProvider>
      <NavigationContainer>
        <AuthProvider>
          <Routes />
        </AuthProvider>
      </NavigationContainer>
    </PaperProvider>
  );
}