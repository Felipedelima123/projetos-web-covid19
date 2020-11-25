import React, { Component } from 'react';
import { View, StyleSheet } from 'react-native';
import MapboxGL, {PointAnnotation,Callout, MapView } from '@react-native-mapbox-gl/maps';

MapboxGL.setAccessToken('pk.eyJ1IjoiY2F0ZWwiLCJhIjoiY2tod2h5NnAzMXJxZjJ4bnAzcWFlcThkZCJ9.Fg1IdFfW3sC_J4Q1MRLAAQ');

const MapBox = () => {
  const renderAnnotations = () => {
    return (
      <PointAnnotation
        id='rocketseat'
        coordinate={[-49.6446024, -27.2108001]}
      >
        <View style={styles.annotationContainer}>
          <View style={styles.annotationFill} />
        </View>
        <Callout title='Rocketseat House' />
      </PointAnnotation>
    )
  }

  return (
    <MapView
      centerCoordinate={[-49.6446024, -27.2108001]}
      style={styles.container}
      showUserLocation
      styleURL={MapboxGL.StyleURL.Dark}
    >
      {renderAnnotations()}
    </MapView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  annotationContainer: {
    width: 30,
    height: 30,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: 'white',
    borderRadius: 15,
  },
  annotationFill: {
    width: 30,
    height: 30,
    borderRadius: 15,
    backgroundColor: '#7159C1',
    transform: [{ scale: 0.8 }],
  }
});

export default MapBox;
