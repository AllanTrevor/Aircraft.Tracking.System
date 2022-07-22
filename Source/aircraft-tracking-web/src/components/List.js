import { Link } from "react-router-dom";

import Button from "react-bootstrap/Button";
import ListGroup from "react-bootstrap/ListGroup";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export default function List(props) {
  return (
    <ListGroup.Item key={props.aircraft.id}>
      <div className="ms-2 me-auto">
        <div className="row mb-3">
          <div className="col-8">
            <span className="h3">{props.aircraft.registration}</span>
          </div>
          <div className="col-4">
            <Link to={"/aircraft/" + props.aircraft.id} className="btn btn-primary btn-sm me-1">
              <FontAwesomeIcon icon="fa-solid fa-pen-to-square" />
            </Link>
            <Button variant="outline-secondary" size="sm">
              <FontAwesomeIcon icon="fa-solid fa-trash-can" />
            </Button>
          </div>
        </div>

        <div className="row mb-1">
          <div className="col-6">
            <div className="row">
              <div className="col-3">Make</div>
              <div className="col-9">{props.aircraft.make}</div>
            </div>
          </div>
          <div className="col-6">
            <div className="row">
              <div className="col-3">Model</div>
              <div className="col-9">{props.aircraft.model}</div>
            </div>
          </div>
        </div>
        <div className="row mb-1">
          <div className="col-6">
            <div className="row">
              <div className="col-4">Spotted On</div>
              <div className="col-8">{props.aircraft.spottedOn}</div>
            </div>
          </div>
        </div>
      </div>
    </ListGroup.Item>
  );
}

export { List };
