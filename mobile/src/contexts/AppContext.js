import BackgroundGeolocation from '@mauron85/react-native-background-geolocation';
import React, { createContext, useContext, useEffect, useState } from 'react';
import { Alert } from 'react-native';

const AppContext = createContext();

export const AppProvider = ({ children }) => {

  const [isTracking, setIsTracking] = useState(false);

  BackgroundGeolocation.configure({
    debug: false,
    locationProvider: BackgroundGeolocation.ACTIVITY_PROVIDER,
    desiredAccuracy: BackgroundGeolocation.HIGH_ACCURACY,
    stationaryRadius: 25,
    distanceFilter: 50,
    interval: 5000,
    fastestInterval: 10000,
    activitiesInterval: 10000,
    startOnBoot: false,
    stopOnTerminate: false,
    startForeground: true,
    notificationsEnabled: true,
    notificationTitle: 'Covid Tracker',
    notificationText: 'Serviço de localização rodando em segundo plano.',
    notificationIconColor: '#7159C1',
    notificationIconSmall: 'ic_laucher_round',
    notificationIconLarge: 'ic_laucher_round',
    activityType: 'Fitness',
  });

  BackgroundGeolocation.on('location', (location) => {
    console.log(location);
  });

  const startTracking = async () => {
    BackgroundGeolocation.checkStatus(({ isRunning, locationServicesEnabled, authorization }) => {
      if (!isRunning) {
        if (!locationServicesEnabled) {
          Alert.alert(
            'Serviços de localização desabilitados',
            'Você gostaria de abrir as configurações de localização?',
            [{
              text: 'Sim',
              onPress: () => BackgroundGeolocation.showLocationSettings(),
            }, {
              text: 'Não',
              style: 'cancel',
            }],
          );
          return false;
        }

        if (authorization === 99) {
          setIsTracking(true);
          BackgroundGeolocation.start();
        } else if (authorization === BackgroundGeolocation.AUTHORIZED) {
          setIsTracking(true);
          BackgroundGeolocation.start();
        } else {
          Alert.alert(
            'Este aplicativo requer rastreamento de localização',
            'Por favor, conceda a permissão',
            [{
              text: 'Ok',
              onPress: () => {
                setIsTracking(true);
                BackgroundGeolocation.start();
              },
            }]
          );
        }
      }
    });
  }

  const stopTracking = async () => {
    BackgroundGeolocation.stop();
    BackgroundGeolocation.removeAllListeners();
    setIsTracking(false);
  }

  useEffect(() => {
    BackgroundGeolocation.checkStatus(({ isRunning }) => {
      if (isRunning && !isTracking) {
        setIsTracking(true);
      } else {
        setIsTracking(false);
      }
    });
  }, [])

  return (
    <AppContext.Provider value={{
      isTracking,

      startTracking,
      stopTracking,
    }}
    >
      {children}
    </AppContext.Provider>
  );
};

export default function useApp() {
  const context = useContext(AppContext);

  return context;
}
