import React, { useEffect, useState } from 'react';

import { getTrucks, removeTruck } from '../../services/truck';

import Modal from '@material-ui/core/Modal';

import AddTruck from '../../Components/AddTruck'
import UpdateTruck from '../../Components/UpdateTruck'

export default function Truck({ token }) {
  const [trucks, setTrucks] = useState([])
  const [truck, setTruck] = useState({ description: '', model: '', modelYear: '', color: '' , image: '', id: '', yearOfManufacture: '' })
  const [openAdd, setOpenAdd] = useState(false);
  const [openUpd, setOpenUpd] = useState(false);
  
  async function getAll() {
    const response = await getTrucks(token);
    setTrucks(response)
  }

  useEffect(() => {
    getAll();
  }, [])

  const headerGroups = ['Modelo', 'Ano', 'Ano Fabricação', 'Cor', 'Ações']

  const handleOpenAdd = () => {
    setOpenAdd(true);
  };

  const handleCloseAdd = async () => {
    await getAll();
    setOpenAdd(false);
  };
  
  const handleOpenUpdate = (truck) => {
    setTruck(truck)
    setOpenUpd(true)
  }

  const handleCloseUpdate = async () => {
    await getAll();
    setOpenUpd(false);
  };

  const handleDelete = async (truck) => {
    setTruck(truck);
    await removeTruck(token, truck.id)
    await getAll();
  }

  return (
    <div className="truck">
      <button type="button" onClick={() => handleOpenAdd()}>Add</button>
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
              <td>
                <button type="button" onClick={() => handleDelete(truck)}>Delete</button>
                <button type="button" onClick={() => handleOpenUpdate(truck)}>Update</button>
              </td>
            </tr>
          ))}
      </tbody>
    </table>

    <Modal
      open={openAdd}
      onClose={handleCloseAdd}
    >
      <AddTruck handleClose={handleCloseAdd} token={token} />
    </Modal>

    <Modal
      open={openUpd}
      onClose={handleCloseUpdate}
    >
      <UpdateTruck handleClose={handleCloseUpdate} truck={truck} token={token} />
    </Modal>
    </div>
  )
}