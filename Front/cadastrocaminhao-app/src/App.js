import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import Login from './screen/Login';
import Truck from './screen/Truck';

import './App.css';

function App() {
  const [token, setToken] = useState(null);

  const updateToken = (data) => {
    setToken(data)
  }

  return (
    <div className="App">
      <Router>
        <Switch>
          <Route path="/truck" component={() => <Truck token={token} />} />
          <Route exact path="/" component={() => <Login setToken={updateToken} token={token} />} />
        </Switch>
      </Router>
    </div>
  );
}

export default App;
