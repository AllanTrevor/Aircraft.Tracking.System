import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Button, Col, Row, Form, Container } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import FormTextField from "../../components/common/FormField.js";
import FormDateTimePicker from "../../components/common/FormDateTimePicker.js";
import FormImagePicker from "../../components/common/FormImagePicker.js";

import ApiService from "../../api/Api.service.js";

import { Formik } from "formik";
import { object, string, date } from "yup";

function Edit() {
  const [
    aircraft = {
      id: 0,
      registration: "",
      make: "",
      model: "",
      location: "",
      spottedOn: "",
      aircraftImagePath: "",
      aircraftImage: "",
    },
    setAircraft,
  ] = useState();

  const [loading, setLoading] = useState(false);

  let navigate = useNavigate();

  const schema = object().shape({
    registration: string()
      .required()
      .matches(
        /^([A-Za-z0-9]{1,2})-([A-Za-z0-9]{1,5})$/,
        'Format should be "[A-Za-z0-9]{1,2})-([A-Z0-9]{1,5}"'
      )
      .max(8, "Registration must be less than 8 charactors"),
    make: string().required().max(128, "Make must be less than 128 charactors"),
    model: string()
      .required()
      .max(128, "Model must be less than 128 charactors"),
    location: string()
      .required()
      .max(225, "Location must be less than 225 charactors"),
    spottedOn: date()
      .required()
      .max(new Date(), "Spotted Date must be in past"),
    aircraftImage: string().required("Aircraft Image is a required field"),
    aircraftImagePath: string().nullable(),
  });

  let { id } = useParams();
  let pageTitle = id > 0 ? "Edit" : "Add";

  useEffect(() => {
    const GetAircraft = async (id) => {
      try {
        setLoading(true);
        const aircraftData = await ApiService.httpGet("/GetById/" + id);
        setAircraft(aircraftData);

        setLoading(false);
      } catch (err) {
        setLoading(false);
        navigate("../", { replace: true });
      }
    };
    if (id && id > 1) {
      GetAircraft(id);
    }
  }, [id]);

  const SaveAircraft = async (data) => {
    try {
      setLoading(true);
      const uri = data && data.id == 0 ? "/Insert" : "/Update";
      const aircraftData = await ApiService.httpPost(uri, data);
      setAircraft(aircraftData);
      setLoading(false);
      navigate("../", { replace: true });
    } catch (err) {
      setLoading(false);
    }
  };

  const handleSubmit = (data) => {
    SaveAircraft(data);
  };

  return (
    <div className="jumbotron">
      <Container>
        <Row className="mb-4">
          <Col>
            <h2 className="card-header">{pageTitle} Spotted Aircraft Detail</h2>
          </Col>
        </Row>
        {loading && (
          <div className="progress">
            <div className="progress-bar w-75"></div>
          </div>
        )}
        {!loading && aircraft && (
          <Row>
            <Formik
              validationSchema={schema}
              onSubmit={handleSubmit}
              initialValues={aircraft}
            >
              {({
                handleSubmit,
                handleChange,
                values,
                errors,
                isValid,
                isSubmitting,
                validateField,
              }) => (
                <Form onSubmit={handleSubmit}>
                  <Row>
                    <Col>
                      <FormTextField
                        as={Col}
                        sm="4"
                        controlId="registration"
                        label="Registration"
                        type="text"
                        name="registration"
                      />
                    </Col>
                    <Col>
                      <FormTextField
                        as={Col}
                        sm="4"
                        controlId="make"
                        label="Make"
                        type="text"
                        name="make"
                      />
                    </Col>
                  </Row>
                  <Row>
                    <Col>
                      <FormTextField
                        as={Col}
                        sm="4"
                        controlId="model"
                        label="Model"
                        type="text"
                        name="model"
                      />
                    </Col>
                    <Col>
                      <FormTextField
                        as={Col}
                        sm="4"
                        controlId="location"
                        label="location"
                        type="text"
                        name="location"
                      />
                    </Col>
                  </Row>
                  <Row>
                    <Col>
                      <FormImagePicker
                        as={Col}
                        sm="4"
                        controlId="aircraftImagePath"
                        label="Image"
                        name="aircraftImagePath"
                        _validateField={validateField}
                      />
                      <FormTextField
                        style={{ display: "none" }}
                        as={Col}
                        sm="4"
                        controlId="aircraftImage"
                        label=""
                        type="hidden"
                        name="aircraftImage"
                      />
                    </Col>
                    <Col>
                      <FormDateTimePicker
                        as={Col}
                        sm="4"
                        controlId="spottedOn"
                        label="Spotted On"
                        name="spottedOn"
                      />
                    </Col>
                  </Row>
                  <Row className="mb-4">
                    <Col>
                      <Col>
                        <Button
                          disabled={!isValid || isSubmitting}
                          type="submit"
                          variant="primary"
                          value="Submit"
                        >
                          <FontAwesomeIcon icon="fa-solid fa-floppy-disk" />{" "}
                          Save
                        </Button>
                      </Col>
                    </Col>
                  </Row>
                </Form>
              )}
            </Formik>
          </Row>
        )}
      </Container>
    </div>
  );
}

export default Edit;
