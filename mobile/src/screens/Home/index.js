import React from 'react';
import { View } from 'react-native';
import GMap from '../../components/GMap';
import styles from './styles';

const Home = () => {
  return (
    <View style={styles.container}>
      <GMap />
    </View>
  );
}

export default Home;
