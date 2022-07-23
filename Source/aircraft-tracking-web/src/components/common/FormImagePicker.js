import React, { useState, useEffect } from "react";
import { Col, Form, InputGroup } from "react-bootstrap";
import { Field } from "formik";

const FormImagePicker = ({
  as,
  md,
  controlId,
  label,
  name,
  stringContent,
  inputGroupPrepend,
  _validateField,
}) => {
  const imageTypeRegex = /image\/(png|jpg|jpeg)/gm;
  var _formRef = null;
  var _fieldName = "";
  var _isValid = true;
  var _error = "";

  const [imageFile, setImageFile] = useState([]);
  const [image, setImage] = useState([]);

  const changeHandler = (e) => {
    const { files } = e.target;
    const validImageFile = [];
    for (let i = 0; i < files.length; i++) {
      const file = files[i];
      if (file.type.match(imageTypeRegex)) {
        validImageFile.push(file);
      }
    }
    if (validImageFile.length) {
      setImageFile(validImageFile);
      return;
    }
    //alert("Selected image is not of valid type!");
    _formRef.errors[_fieldName] = "Selected image is not of valid type!";
    _error = "Selected image is not of valid type!";
    _isValid = false;
    // _validateField(_isValid);
  };

  function validateFileType() {
    let error = "";
    if (!_isValid) {
      error = "Selected image is not of valid type!";
    }
    return error;
  }

  useEffect(
    () => {
      const images = [],
        fileReaders = [];
      let isCancel = false;
      if (imageFile.length) {
        imageFile.forEach((file) => {
          const fileReader = new FileReader();
          fileReaders.push(fileReader);
          fileReader.onload = (e) => {
            const { result } = e.target;
            if (result) {
              images.push(result);
            }
            if (images.length === imageFile.length && !isCancel) {
              setImage(images);
              _formRef.values[_fieldName.split('Path')[0]] = images[0];
            }
          };
          fileReader.readAsDataURL(file);
        });
      }
      return () => {
        isCancel = true;
        fileReaders.forEach((fileReader) => {
          if (fileReader.readyState === 1) {
            fileReader.abort();
          }
        });
      };
    },
    [imageFile],
    _formRef,
    _fieldName
  );

  return (
    <Field
      name={name}
      render={({ field, form }) => {
        _formRef = form;
        _fieldName = field.name;
        const isValid = !form.errors[field.name];
        const isInvalid = form.touched[field.name] && !isValid;
        return (
          <Form.Group as={as} md={md} controlId={controlId}>
            <Form.Label>{label}</Form.Label>
            <InputGroup>
              {inputGroupPrepend}
              <Form.Control
                {...field}
                type="file"
                accept="image/*"
                onChange={changeHandler}
                isValid={form.touched[field.name] && isValid}
                isInvalid={isInvalid}
                feedback={form.errors[field.name]}
              />

              <Form.Control.Feedback type="invalid">
                {form.errors[field.name]}
              </Form.Control.Feedback>
            </InputGroup>
            <div className="mt-2">
              <img src={_formRef.values[_fieldName.split('Path')[0]]} alt="" />
            </div>
          </Form.Group>
        );
      }}
    />
  );
};

FormImagePicker.defaultProps = {
  stringContent: "",
  inputGroupPrepend: null,
};

export default FormImagePicker;
