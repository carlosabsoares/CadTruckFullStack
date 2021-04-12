import React, { useCallback, useRef } from 'react';
import Input from '../../Components/Input';
import { Form } from '@unform/web';

import { updateTruck } from '../../services/truck';

export default function UpdateTruck({ token, handleClose, truck }) {
  const formRef = useRef(null);
  let initialData = {
    model: truck.model,
    description: truck.description,
    modelYear: truck.modelYear,
    color: truck.color,
  };

  const handleSubmit = useCallback(
    async data => {
      try {
      const { model, description, modelYear, color } = data;
      const sendData = {
        id: truck.id, model: Number(model), description, modelYear: Number(modelYear), color
      }
        await updateTruck(token, sendData);
        handleClose()
      } catch (err) {
        console.log(err);
      }
    },
    [handleClose]
  );


  return (
    <div className="modal">
      <Form name="form" ref={formRef} initialData={initialData} onSubmit={handleSubmit}>
        <Input name="description" label="Descrição" />
        <Input name="model" label="Modelo (FH: 1, FM: 2)" />
        <Input name="modelYear" label="Ano do Modelo" />
        <Input name="color" label="Cor" />

        <button>Update</button>
      </Form>
    </div>
  )
}