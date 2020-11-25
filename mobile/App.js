import React from 'react';
import { StyleSheet, View } from 'react-native';
import MapBox from './components/MapBox';

export default function App() {
  return (
    <MapBox />
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
