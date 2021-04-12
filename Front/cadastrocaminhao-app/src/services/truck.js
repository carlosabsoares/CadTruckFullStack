import axios from 'axios';

export const getTrucks = async (token) => {
  console.log('token', token)
  const response = await axios.get('https://localhost:44393/v1/cadTruck/truck/getAll', {
    headers: {
      'Authorization': `Bearer ${token}` ,
    }});
  return response.data
}


export const addTruck = async (token, { description, model, modelYear, color, image }) => {
  await axios.post('https://localhost:44393/v1/cadTruck/truck/create', { description, model, modelYear, color, image }, {
    headers: {
      'Authorization': `Bearer ${token}` ,
    }});
}

export const removeTruck = async (token, id) => {
  await axios.delete(`https://localhost:44393/v1/cadTruck/truck/delete?id=${id}`, {
    headers: {
      'Authorization': `Bearer ${token}` 
    }});
}

export const updateTruck = async (token, { id, description, model, modelYear, color, image }) => {
  await axios.put('https://localhost:44393/v1/cadTruck/truck/update', { id, description, model, modelYear, color, image }, {
    headers: {
      'Authorization': `Bearer ${token}` 
    }});
}
