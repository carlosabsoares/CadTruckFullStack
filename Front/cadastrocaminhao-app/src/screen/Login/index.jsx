import React, { useCallback, useState } from 'react';
import { Redirect } from 'react-router-dom'

import { handleLogin } from '../../services/login';

export default function Login({ setToken, token }) {
  const [userLogin, setUserLogin] = useState('');
  const [userPassword, setUserPassword] = useState('');

  const handleSubmit = useCallback(
    async (login, password) => {
      try {
        const receivedToken = await handleLogin({ login, password })
        setToken(receivedToken)
      } catch(err) {
          console.log(err)
      }
    }, [setToken]
  )

  if (token) return <Redirect to="/truck" />

  return (
    <div className="login">
      <label htmlFor="login">
        Login
      </label>
        <input type="text" name="login" onChange={(e) => setUserLogin(e.target.value)}/>
      <label htmlFor="password">
        Password
      </label>
        <input type="password" onChange={(e) => setUserPassword(e.target.value)} name="password"/>
      <button className="btn" type="button" onClick={() => handleSubmit(userLogin, userPassword)}>Login</button>
      <br/>
      <div>
        Para testes: Login e Senha: carlos / carlos
      </div>
    </div>

    )
}
