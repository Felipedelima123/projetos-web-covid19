import { positionsApi } from './api';

export async function sendPosition(position) {
  try {
    const response = await positionsApi.post('/position', {
      position,
    });

    return response;
  } catch (error) {
    return { error }
  }
}