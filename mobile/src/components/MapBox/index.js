import BackgroundGeolocation from '@mauron85/react-native-background-geolocation';
import MapboxGL, { MapView } from '@react-native-mapbox-gl/maps';
import React, { useEffect, useState } from 'react';
import { ActivityIndicator, View } from 'react-native';
import styles from './styles';

MapboxGL.setAccessToken('pk.eyJ1IjoiY2F0ZWwiLCJhIjoiY2tod2h5NnAzMXJxZjJ4bnAzcWFlcThkZCJ9.Fg1IdFfW3sC_J4Q1MRLAAQ');

const MapBox = () => {

  const [location, setLocation] = useState();
  const [coordinates, setCoordinates] = useState();

  useEffect(() => {
    BackgroundGeolocation.getCurrentLocation((location) => {
      setLocation(location);
    });

    MapboxGL.locationManager.start();

    return () => {
      MapboxGL.locationManager.stop();
    };
  }, []);

  useEffect(() => {
    if (location) {
      setCoordinates([
        location.longitude,
        location.latitude,
      ]);
    }
  }, [location])

  if (!location) {
    return (
      <View style={styles.loadingContainer}>
        <ActivityIndicator size="large" />
      </View>
    );
  }

  return (
    <MapView
      centerCoordinate={coordinates}
      style={styles.container}
    >
      <MapboxGL.Camera zoomLevel={14} followUserLocation />
      <MapboxGL.UserLocation />
    </MapView>
  );
}



export default MapBox;
