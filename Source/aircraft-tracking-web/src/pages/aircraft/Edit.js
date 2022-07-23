import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Button, Col, Form } from "react-bootstrap";

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
      .matches(/^([A-Z0-9]{1,2})-([A-Z0-9]{1,5})$/, "Format should be \"[A-Z0-9]{1,2})-([A-Z0-9]{1,5}\"")
      .max(8, "Registration must be less than 8 charactors"),
    make: string().required().max(128, "Registration must be less than 128 charactors"),
    model: string().required().max(128, "Registration must be less than 128 charactors"),
    location: string().required().max(225, "Registration must be less than 225 charactors"),
    spottedOn: date()
      .required()
      .max(new Date(), "Spotted Date must be in past"),
    aircraftImage: string().required("Aircraft Image is a required field"),
    aircraftImagePath: string().nullable(),
  });

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
    <div>
      {loading && <h1>Loading...</h1>}
      {!loading && aircraft && (
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
              <Col>
                <FormDateTimePicker
                  as={Col}
                  sm="4"
                  controlId="spottedOn"
                  label="Spotted On"
                  name="spottedOn"
                />
              </Col>
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
                <Button
                  disabled={!isValid || isSubmitting}
                  variant="success"
                  as="input"
                  size="lg"
                  type="submit"
                  value="Submit"
                />
              </Col>

              {/* <Col>
                <pre style={{ margin: "0 auto" }}>
                  {JSON.stringify(
                    { ...values, ...errors, isValid, isSubmitting },
                    null,
                    2
                  )}
                </pre>
              </Col> */}
            </Form>
          )}
        </Formik>
      )}
    </div>
  );
}

export default Edit;
