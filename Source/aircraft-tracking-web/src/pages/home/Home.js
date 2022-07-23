import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
// import { Button, Col, Form } from "react-bootstrap";

import ApiService from "../../api/Api.service.js";

import { List } from "../../components/List.js";
// import FormTextField from "../../components/common/FormField.js";

function Home() {
  const [aircrafts, setAircrafts] = useState([]);
  const [filteredAircrafts, setFilteredAircrafts] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const testApi = async () => {
      try {
        setLoading(true);
        const result = await ApiService.httpGet("/GetAll");
        setAircrafts(result);
        setFilteredAircrafts(result);
        setLoading(false);
      } catch (err) {
        setLoading(false);
      }
    };

    testApi();
  }, []);

  const searchAircrafts = (e) => {
    var result = aircrafts.filter((x)=> { return x.registration.toLowerCase().includes(e.target.value) || x.make.toLowerCase().includes(e.target.value) || x.model.toLowerCase().includes(e.target.value)})
    setFilteredAircrafts(result);
  };

  return (
    <div className="row">
      <div className="col-12 align-self-end">
        <form className="form-inline float-right">
          <input
            className="form-control mr-sm-2"
            type="text"
            placeholder="Search"
            onChange={searchAircrafts}
          />
        </form>
      </div>
      <div className="table-responsive row-top-gap">
        <table id="example" className="table table-striped no-footer">
          <thead>
            <tr>
              <th>Registration</th>
              <th>Make</th>
              <th>Model</th>
              <th>Location</th>
              <th>Spotted On</th>
              <th>View</th>
              <th>Edit</th>
              <th>Delete</th>
            </tr>
          </thead>
          <tbody>
            {loading && (
              <tr>
                <td colSpan={8}>
                  <span>Loading...</span>
                </td>
              </tr>
            )}
            {filteredAircrafts && filteredAircrafts.map((aircraft) => {
                return <List key={aircraft.id} aircraft={aircraft}></List>;
              })}
          </tbody>
          <tfoot>
            <tr>
              <td colSpan={8}>
                <Link
                  to={"/aircraft/add"}
                  className="btn btn-primary btn-sm me-1 float-right"
                >
                  <FontAwesomeIcon icon="fa-solid fa-plus" />
                  <span>Add New</span>
                </Link>
              </td>
            </tr>
          </tfoot>
        </table>
      </div>
    </div>
  );
}

export default Home;
