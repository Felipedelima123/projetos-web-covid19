import axios from 'axios';

export default api = axios.create({
  baseURL: 'http://192.168.0.3:54926/api/',
});


async function getConfig(config) {
  config.headers.post['Accept'] = 'application/json';
  config.headers.post['Content-Type'] = 'application/json';

  return config;
}

api.interceptors.request
  .use(async (config) => getConfig(config), (error) => Promise.reject(error));
