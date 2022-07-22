import React from 'react';
import logo from './logo.svg';
import './App.css';
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link
} from 'react-router-dom';

import Home from './pages/home/Home.js';
import Aircraft from './pages/aircraft/Aircraft.js';

function App() {

  return (
    <Router>
      <div className="App">
      </div>
      <Routes>
        <Route exact path='/' element={< Home />}></Route>
        <Route exact path='/aircraft/:id' element={< Aircraft />}></Route>
      </Routes>
    </Router>
  );
}

export default App;
