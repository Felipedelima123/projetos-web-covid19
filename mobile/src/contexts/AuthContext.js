import BackgroundGeolocation from '@mauron85/react-native-background-geolocation';
import React, {
  createContext, useContext, useState
} from 'react';
import * as auth from '../services/auth';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(false);

  async function signOut() {
    BackgroundGeolocation.stop();
    BackgroundGeolocation.deleteAllLocations();
    BackgroundGeolocation.removeAllListeners();
    setUser(null);
  }

  async function signIn(user) {
    setLoading(true);
    
    setUser(user);
    setLoading(false);
  }

  return (
    <AuthContext.Provider value={{
      signed: !!user,
      user,
      loading,
      signIn,
      signOut,
    }}
    >
      {children}
    </AuthContext.Provider>
  );
};

export default function useAuth() {
  const context = useContext(AuthContext);

  return context;
}
