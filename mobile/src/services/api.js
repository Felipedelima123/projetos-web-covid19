/* eslint-disable no-param-reassign */
import axios from 'axios';
import AsyncStorage from '@react-native-async-storage/async-storage';

export const authApi = axios.create({
  baseURL: 'http://192.168.0.3:3005',
});

export const positionsApi = axios.create({
  baseURL: 'http://192.168.0.3:3003/',
});

async function getConfig(config) {
  const storageLogin = await AsyncStorage.getItem('@RNapp:login');

  if (storageLogin) {
    const loginJson = JSON.parse(storageLogin);

    config.headers.post['Content-Type'] = 'application/json';
    config.headers.Authorization = loginJson.token;
  }

  return config;
}

positionsApi.interceptors.request
  .use(async (config) => getConfig(config), (error) => Promise.reject(error));
