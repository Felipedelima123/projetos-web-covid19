import BackgroundGeolocation from '@mauron85/react-native-background-geolocation';
import React, { createContext, useContext, useEffect, useState } from 'react';
import { Alert } from 'react-native';
import { positions } from '../services/requests';

const AppContext = createContext();

export const AppProvider = ({ children }) => {

  const [isTracking, setIsTracking] = useState(false);

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
    BackgroundGeolocation.checkStatus(({ isRunning }) => {
      if(isRunning) {
        BackgroundGeolocation.stop();
        BackgroundGeolocation.removeAllListeners();
        BackgroundGeolocation.deleteAllLocations();
        setIsTracking(false);
      }
    });
  }

  useEffect(() => {
    // const positionsUrl = 'http://192.168.0.3:54926/api/UserPositionsApi';

    BackgroundGeolocation.configure({
      debug: false,
      locationProvider: BackgroundGeolocation.DISTANCE_FILTER_PROVIDER,
      desiredAccuracy: BackgroundGeolocation.HIGH_ACCURACY,
      stationaryRadius: 10,
      distanceFilter: 15,
      interval: 5000,
      startOnBoot: false,
      stopOnTerminate: false,
      startForeground: true,
      notificationsEnabled: true,
      notificationTitle: 'Covid Tracker',
      notificationText: 'Serviço de localização rodando em segundo plano.',
      notificationIconColor: '#7159C1',
      notificationIconSmall: 'ic_laucher_round',
      notificationIconLarge: 'ic_laucher_round',
    });
  
    BackgroundGeolocation.on('location', async (location) => {
      await positions(location);
    });
    
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
