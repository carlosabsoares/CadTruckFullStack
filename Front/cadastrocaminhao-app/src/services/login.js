import axios from 'axios';

export const handleLogin = async ({ login, password }) => {
  const response = await axios.post('https://localhost:44393/v1/cadTruck/user/validateUser', { login, password });
  return response.data.data?.token
}
