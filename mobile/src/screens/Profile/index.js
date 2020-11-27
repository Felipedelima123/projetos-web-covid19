import React from 'react';
import { View } from 'react-native';
import { Button } from 'react-native-paper';
import useAuth from '../../contexts/AuthContext';
import useApp from '../../contexts/AppContext';
import styles from './styles';

const Profile = () => {
  const { signOut } = useAuth();
  const { isTracking, startTracking, stopTracking } = useApp();

  return (
    <View style={styles.container}>
      <Button
        mode="contained"
        style={styles.button}
        icon={!isTracking ? "play" : "pause"}
        onPress={!isTracking ? startTracking : stopTracking}
      >
        {!isTracking ? 'Iniciar' : 'Parar'}
      </Button>

      <Button
        icon="logout"
        mode="contained"
        style={styles.button}
        onPress={signOut}
      >
        Sair
      </Button>
    </View>
  );
}

export default Profile;
