import React from "react";
import logo from "./logo.svg";
import "./App.css";
// import {
//   BrowserRouter as Router,
//   Routes,
//   Route,
//   Link
// } from 'react-router-dom';
import { RouteObject } from "react-router-dom";
import { Outlet, Link, useRoutes, useParams } from "react-router-dom";

import Home from "./pages/home/Home.js";
import Aircraft from "./pages/aircraft/Aircraft.js";
import View from "./pages/aircraft/View";
import Edit from "./pages/aircraft/Edit";

function App() {
  let routes = [
    {
      path: "/",
      element: <Home />,
    },
    {
      path: "/aircraft/:id",
      element: <View />,
    },
    {
      path: "/aircraft/edit/:id",
      element: <Edit />,
    },
    {
      path: "/aircraft/add",
      element: <Edit />,
    },
    { path: "*", element: <Home /> },
  ];

  let element = useRoutes(routes);

  return (
    <div className="container-fluid">
      <div className="row">
        <div className="col-md-12">
          <nav className="navbar navbar-expand-lg navbar-light bg-light static-top">
            {/* <Link to={"/"} > Aircraft Spotters </Link> */}
            <span className="navbar-brand"> Aircraft Spotters </span>
          </nav>
          <nav>
            <ol className="breadcrumb">
              <li className="breadcrumb-item">
              <Link to={"/"} >Home</Link>
              </li>
            </ol>
          </nav>
          <div className="jumbotron">{element}</div>
        </div>
      </div>
    </div>
  );
}

export default App;
