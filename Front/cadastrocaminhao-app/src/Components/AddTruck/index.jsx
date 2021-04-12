import React, { useCallback, useRef } from 'react';
import Input from '../../Components/Input';

import { Form } from '@unform/web';

import { addTruck } from '../../services/truck';


export default function AddTruck({ token, handleClose }) {
  const formRef = useRef(null);
  let initialData = {
    model: '',
    description: '',
    modelYear: '',
    color: '',
  };

  const handleSubmit = useCallback(
    async data => {
      try {
        const { model, description, modelYear, color } = data;
        const sendData = {
          model: Number(model), description, modelYear: Number(modelYear), color
        }
        await addTruck(token, sendData);
        handleClose()
      } catch (err) {
        console.log(err);
      }
    },
    [handleClose]
  );

  const options = [
    { value: '1', label: 'FH' },
    { value: '2', label: 'FM' },
  ]

  return (
    <div className="modal">
      <Form name="form" ref={formRef} initialData={initialData} onSubmit={handleSubmit}>
        <Input name="description" label="Descrição" />
        <Input name="model" label="Modelo (FH: 1, FM: 2)" />
        <Input name="modelYear" label="Ano do Modelo" />
        <Input name="color" label="Cor" />

        <button>Add</button>
      </Form>
    </div>
  )
}