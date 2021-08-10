import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';
import reportWebVitals from './reportWebVitals';

import Home from './pages/home/App';
import NotFound from './pages/notfound/notfound';
import Login from './pages/login/login'

const routing = (
  <Router>
    <div>
      <Switch>
        <Route path="/home" component={Home} />
        <Route exact path="/" component={Login} />
        <Route exact path="/notfound" component={NotFound} />
        <Redirect to = "/notfound" />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

reportWebVitals();
