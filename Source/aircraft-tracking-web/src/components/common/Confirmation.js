import React, { useState, useEffect } from "react";
import { Button, Modal } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Moment from "react-moment";

export default function Confirmation(props) {
  let { title, message, showModel, doConfirm, doReject } = props;

  const [show, setShow] = useState(false);

  useEffect(() => {
    setShow(showModel);
  }, [showModel]);  

  const handleClose = () => {
    setShow(false);
    doReject();
  };

  const confirmationHandler = () => {
    setShow(false);
    doConfirm();
  };

  return (
    <>
      <Modal
        show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}
      >
        <Modal.Header closeButton>
          <Modal.Title>{title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>{message}</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="danger" onClick={confirmationHandler}>
            Confirm
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export { Confirmation };
