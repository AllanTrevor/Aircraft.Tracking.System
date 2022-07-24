import React from "react";
import logo from "./logo.svg";
import "./App.css";
import {
  Outlet,
  Navigate,
  NavLink,
  Link,
  useRoutes,
  useParams,
} from "react-router-dom";
import useBreadcrumbs from "use-react-router-breadcrumbs";

import Home from "./pages/home/Home.js";
import Aircraft from "./pages/aircraft/Aircraft.js";
import View from "./pages/aircraft/View";
import Edit from "./pages/aircraft/Edit";

function App() {
  const CustomPropsBreadcrumb = ({ title }) => <span>{title}</span>;

  let routes = [
    {
      path: "/aircraft",
      element: <Home />,
    },
    {
      path: "/aircraft/view/:id",
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
    { path: "*", element: <Navigate to="/aircraft" replace /> },
  ];

  const Breadcrumbs = () => {
    const breadcrumbs = useBreadcrumbs(routes);

    return (
      <>
        {breadcrumbs.map(({ match, breadcrumb }) => (
          <li key={match.pathname + Math.random()} className="breadcrumb-item">
            <Link to={match.pathname}>{breadcrumb}</Link>
          </li>
        ))}
      </>
    );
  };

  let element = useRoutes(routes);

  return (
    <div className="container-fluid">
      <div className="row">
        <div className="col-md-12">
          <nav className="navbar navbar-expand-lg navbar-light bg-light static-top">
            <h2 className="card-header">Aircraft Spotters</h2>
          </nav>
          <nav>
            <ol className="breadcrumb">
              <Breadcrumbs></Breadcrumbs>
            </ol>
          </nav>
          <div className="jumbotron">{element}</div>
        </div>
      </div>
    </div>
  );
}

export default App;
