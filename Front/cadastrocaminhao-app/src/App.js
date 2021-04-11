import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import Login from './screen/Login';
import Truck from './screen/Truck';

import './App.css';

function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route path="/truck" component={Truck} />
          <Route exact path="/" component={Login} />
        </Switch>
      </Router>
    </div>
  );
}

export default App;
