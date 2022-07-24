import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { Button, Container, Col, Row, Stack } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import ApiService from "../../api/Api.service.js";

import { List } from "../../components/List.js";
import Confirmation from "../../components/common/Confirmation.js";

function Home() {
  const [aircrafts, setAircrafts] = useState([]);
  const [filteredAircrafts, setFilteredAircrafts] = useState([]);
  const [loading, setLoading] = useState(false);

  const [showModel, setShow] = useState(false);
  const [deletingAircraftId, setDeletingAircraft] = useState(false);

  const searchRef = React.createRef();

  useEffect(() => {
    setDeletingAircraft(0);
    GetAircrafts();
  }, []);

  const GetAircrafts = async () => {
    try {
      setLoading(true);
      searchRef.current.value = "";
      const result = await ApiService.httpGet("/GetAll");
      setAircrafts(result);
      setFilteredAircrafts(result);
      setLoading(false);
    } catch (err) {
      setLoading(false);
    }
  };

  const searchAircrafts = (searchText) => {
    var result = aircrafts.filter((x) => {
      return (
        x.registration.toLowerCase().includes(searchText) ||
        x.make.toLowerCase().includes(searchText) ||
        x.model.toLowerCase().includes(searchText)
      );
    });
    setFilteredAircrafts(result);
  };

  const deleteAircrafts = async (id) => {
    try {
      setLoading(true);
      const deleteResult = await ApiService.httpPost("/Delete/" + id);
      setLoading(false);
      GetAircrafts();
    } catch (err) {
      setLoading(false);
    }
  };

  const deleteAircraft = (id) => {
    setDeletingAircraft(id);
    setShow(true);
  };

  return (
    <>
      <Confirmation
        title="Delete Aircraft"
        message="Do you want to delete Aircraft?"
        showModel={showModel}
        doConfirm={() => deleteAircrafts(deletingAircraftId)}
        doReject={() => {
          setDeletingAircraft(0);
          setShow(false);
        }}
      ></Confirmation>
      <div className="jumbotron">
        <Container>
          <Row className="mb-4">
            <Col>
              <h2 className="card-header">Spotted Aircrafts</h2>
            </Col>
          </Row>
          <Row>
            <Col md={{ span: 4, offset: 8 }}>
              <Stack direction="horizontal" gap={0}>
                <input
                  ref={searchRef}
                  className="form-control form-control-sm mr-sm-2"
                  type="text"
                  placeholder="Search"
                  onChange={(e) => searchAircrafts(e.target.value)}
                />
                <Button type="button" variant="primary" size="sm" onClick={GetAircrafts}>
                  <FontAwesomeIcon icon="fa-solid fa-arrows-rotate" />
                </Button>
              </Stack>
            </Col>
          </Row>
          <Row>
            <Col>
              <div className="table-responsive row-top-gap">
                <table id="example" className="table table-striped no-footer">
                  <thead>
                    <tr>
                      <th>Registration</th>
                      <th>Make</th>
                      <th>Model</th>
                      <th>Location</th>
                      <th>Spotted On</th>
                      <th>Actions</th>
                    </tr>
                  </thead>
                  <tbody>
                    {loading && (
                      <tr>
                        <td colSpan={8}>
                          <div className="col-md-12">
                            <div className="progress">
                              <div className="progress-bar w-75"></div>
                            </div>
                          </div>
                        </td>
                      </tr>
                    )}
                    {filteredAircrafts &&
                      filteredAircrafts.map((aircraft) => {
                        return (
                          <List
                            key={aircraft.id}
                            aircraft={aircraft}
                            deleteAircraft={deleteAircraft}
                          ></List>
                        );
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
            </Col>
          </Row>
        </Container>
      </div>
    </>
  );
}

export default Home;
