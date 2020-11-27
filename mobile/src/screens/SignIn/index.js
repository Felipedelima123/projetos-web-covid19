import React from 'react';
import { View } from 'react-native';
import { Button, TextInput } from 'react-native-paper';
import useAuth from '../../contexts/AuthContext';
import styles from './styles';

const SignIn = () => {
  const [username, setUsername] = React.useState('');
  const [password, setPassword] = React.useState('');
  const { signIn, loading } = useAuth();

  const handleSignIn = async () => {
    const user = {
      username,
      password
    }

    await signIn(user);
  };

  if (loading) {
    return (
      <View style={styles.loadingContainer}>
        <ActivityIndicator size="large" />
      </View>
    );
  }

  return (
    <View style={styles.container}>
      <TextInput
        label="Usuário"
        value={username}
        onChangeText={text => setUsername(text)}
        mode="outlined"
      />

      <TextInput
        label="Senha"
        value={password}
        onChangeText={text => setPassword(text)}
        mode="outlined"
      />

      <Button
        icon="login"
        mode="contained"
        onPress={handleSignIn}
        style={styles.button}
      >
        Entrar
      </Button>

    </View>
  );
}

export default SignIn;
