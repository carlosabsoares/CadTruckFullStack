import axios from 'axios';

const { CancelToken } = axios;

const api = axios.create({
  baseURL: env.API_CONQUISTA,
});

api.interceptors.request.use(config => {
  const { token } = store.getState().auth;

  const headers = { ...config.headers };

  if (token) {
    headers.Authorization = `${token.tokenType} ${token.accessToken}`;
  }

  return { ...config, headers };
});

export const createCancelToken = () => {
  return CancelToken.source();
};

export default api;
