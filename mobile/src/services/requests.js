import api from './api';

export async function signIn(user) {
  try {
    const response = await api.post(
      '/login', {
      username: user.username,
      password: user.password,
    });

    return response;
  } catch (error) {
    return { error }
  }
}

export async function positions(location) {
  try {
    const response = await api.post(
      '/UserPositionsApi', {
      Latitude: location.latitude,
      Longitude: location.longitude,
      UserId: 1
    });

    return response;
  } catch (error) {
    return { error }
  }
}
