import { authApi } from './api';

export async function signIn(user) {
  try {
    const response = await authApi.post(
      '/login', {
      username: user.username,
      password: user.password,
    });

    return response;
  } catch (error) {
    return { error }
  }
}
