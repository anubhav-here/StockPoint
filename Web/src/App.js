import { AppBar } from '@material-ui/core';
import React from 'react';
// import logo from './logo.svg';
import './App.css';
import DenseAppBar from './AppBar';
import Dashboard from './Dashboard';

function App() {
  return (
    <div className="App">
      <DenseAppBar />
      <div class="jumbotron">
  <h1 class="display-4">Welcome to StockPoint!</h1>
  <p class="lead">We're here to help you with all of your inventory hassles.</p>
  <hr class="my-4" />
  <p>Add / Search for purchased stock with the click of a button.</p>
      </div>

      <Dashboard/>
    </div>
  );
}

export default App;
