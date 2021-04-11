import React, { useCallback, useState } from 'react';
import { Redirect } from 'react-router-dom'

import { handleLogin } from '../../services/login';

export default function Login() {
  const [token, setToken] = useState(null);
  const [userLogin, setUserLogin] = useState('');
  const [userPassword, setUserPassword] = useState('');

  const handleSubmit = useCallback(
    async (login, password) => {
      try {
        const receivedToken = await handleLogin({ login, password })
        console.log('token:', receivedToken)
        setToken(receivedToken)
      } catch(err) {
          console.log(err)
      }
    }, []
  )

  if (token) return <Redirect to="/truck" />

  return (
    <div></div>
      <label htmlFor="login">
        <input type="text" name="login" onChange={(e) => setUserLogin(e.target.value)}/>
      </label>
      <label htmlFor="password">
        <input type="password" onChange={(e) => setUserPassword(e.target.value)} name="password"/>
      </label>
      <button type="button" onClick={() => handleSubmit(userLogin, userPassword)}>Login</button>
    </div>
    )
}
