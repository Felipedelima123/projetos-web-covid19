import React from 'react';
import { Text, View } from 'react-native';
import styles from './styles';
import MapBox from '../../components/MapBox';

const Home = () => {
  return (
    <View style={styles.container}>
      <MapBox />
    </View>
  );
}

export default Home;
