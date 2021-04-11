import React, { useEffect, useState } from 'react';

import { getTrucks, addTruck, removeTruck, updateTruck } from '../../services/truck';

export default function AddTruck() {
  const [trucks, setTrucks] = useState([])
  const [truck, setTruck] = useState({ description: '', model: '', modelYear: '', color: '' , image: '', id: '', yearOfManufacture: '' })

  useEffect(() => {
    async function getAll() {
      const response = await getTrucks();
      setTrucks(response)
    }
    getAll();
  }, [])

  const { id, description, model, modelYear, color, image, yearOfManufacture } = truck;
  const headerGroups = ['Modelo', 'Ano', 'Ano Fabricação', 'Cor']

  return (
    <div>
      <button type="button" onClick={() => addTruck({ description, model, modelYear, yearOfManufacture, color, image })}>Add</button>
      <button type="button" onClick={() => removeTruck(id)}>Delete</button>
      <button type="button" onClick={() => updateTruck({ id, description, model, modelYear, yearOfManufacture, color, image })}>Update</button>

      <table>
      <thead>
        <tr>
          {headerGroups.map(column => (<th>{column}</th>))}
        </tr>
      </thead>
      <tbody>
        {trucks.map(truck => 
          (
            <tr>
              <td>{truck.model === 1 ? 'FH' : 'FM'}</td>
              <td>{truck.modelYear}</td>
              <td>{truck.yearOfManufacture}</td>
              <td>{truck.color}</td>
            </tr>
          ))}
      </tbody>
    </table>  
    </div>
  )
}