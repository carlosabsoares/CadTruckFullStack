import axios from 'axios';

export const getTrucks = async () => {
  const response = await axios.get('https://localhost:44393/v1/cadTruck/truck/getAll');
  return response.data
}


export const addTruck = async ({ description, model, modelYear, color, image }) => {
  await axios.post('https://localhost:44393/v1/cadTruck/truck/create', { description, model, modelYear, color, image });
}

export const removeTruck = async (id) => {
  await axios.delete('https://localhost:44393/v1/cadTruck/truck/delete', { id });
}

export const updateTruck = async ({ id, description, model, modelYear, color, image }) => {
  await axios.put('https://localhost:44393/v1/cadTruck/truck/delete', { id, description, model, modelYear, color, image });
}
