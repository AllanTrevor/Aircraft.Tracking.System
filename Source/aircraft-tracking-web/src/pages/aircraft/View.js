import React, { useState, useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import { Container, Col, Row, Form } from "react-bootstrap";
import Moment from "react-moment";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import ApiService from "../../api/Api.service.js";

function View() {
  const [aircraft, setAircraft] = useState();
  const [loading, setLoading] = useState(false);

  let { id } = useParams();

  useEffect(() => {
    const GetAircraft = async (id) => {
      try {
        setLoading(true);
        const aircraftData = await ApiService.httpGet("/GetById/" + id);
        setAircraft(aircraftData);
        setLoading(false);
      } catch (err) {
        setLoading(false);
      }
    };

    GetAircraft(id);
  }, [id]);

  return (
    <div className="jumbotron">
      <Container>
        <Row className="mb-4">
          <Col>
            <h2 className="card-header">Spotted Aircraft Detail</h2>
          </Col>
        </Row>
        {loading && (
          <div className="progress">
            <div className="progress-bar w-75"></div>
          </div>
        )}
        {!loading && aircraft && (
          <>
            <Row>
              <Col>
                <Form.Group className="mb-3" controlId="fgRegistration">
                  <Form.Label>Registration</Form.Label>
                  <Form.Text className="text-reset fw-bold">
                    {aircraft.registration}
                  </Form.Text>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group className="mb-3" controlId="fgMake">
                  <Form.Label>Make</Form.Label>
                  <Form.Text className="text-reset fw-bold">
                    {aircraft.make}
                  </Form.Text>
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group className="mb-3" controlId="fgModel">
                  <Form.Label>Model</Form.Label>
                  <Form.Text className="text-reset fw-bold">
                    {aircraft.model}
                  </Form.Text>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group className="mb-3" controlId="fgLocation">
                  <Form.Label>Location</Form.Label>
                  <Form.Text className="text-reset fw-bold">
                    {aircraft.location}
                  </Form.Text>
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group className="mb-3" controlId="fgImage">
                  <Form.Label>Image</Form.Label>
                </Form.Group>
                <Form.Group>
                  <img
                    className="img-thumbnail rounded"
                    alt=""
                    src={aircraft.aircraftImage}
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group className="mb-3" controlId="fgSpottedOn">
                  <Form.Label>Sppotted On</Form.Label>
                  <Form.Text className="text-reset fw-bold">
                    <Moment local>{aircraft.spottedOn}</Moment>
                  </Form.Text>
                </Form.Group>
              </Col>
            </Row>
            <Row className="mt-4">
              <Col xs={6}>
                <Link
                  to={"/aircraft/edit/" + aircraft.id}
                  key={aircraft.id}
                  className="btn btn-primary"
                >
                  <FontAwesomeIcon icon="fa-solid fa-pen-to-square" /> Edit
                </Link>
              </Col>
            </Row>
          </>
        )}
      </Container>
    </div>
  );
}
export default View;
