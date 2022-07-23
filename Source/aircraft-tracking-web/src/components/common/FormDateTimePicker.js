import React from "react";
import { Form, InputGroup } from "react-bootstrap";
import { Field } from "formik";

const FormDateTimePicker = ({
  as,
  md,
  controlId,
  label,
  name,
  inputGroupPrepend,
}) => {
  return (
    <Field
      name={name}
      render={({ field, form }) => {
        const isValid = !form.errors[field.name];
        const isInvalid = form.touched[field.name] && !isValid;
        return (
          <Form.Group as={as} md={md} controlId={controlId}>
            <Form.Label>{label}</Form.Label>
            <InputGroup>
              {inputGroupPrepend}
              <Form.Control
                  {...field}
                  type="datetime-local"
                  isValid={form.touched[field.name] && isValid}
                  isInvalid={isInvalid}
                  feedback={form.errors[field.name]}
                />
              <Form.Control.Feedback type="invalid">
                {form.errors[field.name]}
              </Form.Control.Feedback>
            </InputGroup>
          </Form.Group>
        );
      }}
    />
  );
};

FormDateTimePicker.defaultProps = {
  inputGroupPrepend: null,
};

export default FormDateTimePicker;
