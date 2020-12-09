import BackgroundGeolocation from '@mauron85/react-native-background-geolocation';
import React, { useEffect, useState } from 'react';
import { View } from 'react-native';
import MapView, { PROVIDER_GOOGLE } from 'react-native-maps';
import styles from './styles';

const GMap = () => {
  const [currentLocation, setcurrentLocation] = useState();
  const [marginBottom, setmarginBottom] = useState(1);

  useEffect(() => {
    BackgroundGeolocation.getCurrentLocation((location) => {

      setcurrentLocation({
        latitude: location.latitude,
        longitude: location.longitude,
        latitudeDelta: 0.01,
        longitudeDelta: 0.01,
      });
    });
  }, []);

  const handleRegionChange = (region) => {
    const { latitude, longitude } = region.nativeEvent.coordinate;

    setcurrentLocation({
      latitude,
      longitude,
      latitudeDelta: 0.01,
      longitudeDelta: 0.01,
    });
  }

  return (
    <View style={styles.container}>
      <MapView
        style={[styles.map, { marginBottom }]}
        onMapReady={() => setmarginBottom(0)}
        provider={PROVIDER_GOOGLE}
        initialRegion={currentLocation}
        onUserLocationChange={handleRegionChange}
        rotateEnabled={false}
        showsUserLocation
        showsMyLocationButton
        zoomControlEnabled
      >
      </MapView>
    </View>
  );
};

export default GMap;