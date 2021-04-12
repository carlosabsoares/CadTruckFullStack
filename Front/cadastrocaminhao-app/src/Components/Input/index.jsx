import React, { useEffect, useRef, useState } from 'react';
import { useField } from '@unform/core';

export default function Input({ name, label, ...rest }) {
  const { registerField, fieldName, defaultValue, error } = useField(name);
  const inputRef = useRef(null);
  const [inputValue, setInputValue] = useState(defaultValue);

  const style = { display: 'flex', flexDirection: 'column', flexGrow: '1', margin: '5px' };

  useEffect(() => {
    registerField({
      name: fieldName,
      ref: inputRef.current,
      path: 'value',
    });
  }, [registerField, fieldName]);

  const handleChange = e => {
    const { value } = e.target;
    return setInputValue(value);
  };

  return (
    <div className="form-group" style={style}>
      <label>
        <b>{label}</b>
      </label>
      <input
        className={`form-control`}
        ref={inputRef}
        defaultValue={defaultValue}
        value={inputValue}
        onChange={e => handleChange(e)}
        {...rest}
      />
      {error && <span className="error">{error}</span>}
    </div>
  );
}
