import { Link } from "react-router-dom";

import Button from "react-bootstrap/Button";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export default function List(props) {
  return (
    <tr key={props.aircraft.id}>
      <td>{props.aircraft.registration}</td>
      <td>{props.aircraft.make}</td>
      <td>{props.aircraft.model}</td>
      <td>{props.aircraft.location}</td>
      <td>{props.aircraft.spottedOn}</td>
      <td>
        <Link
          to={"/aircraft/" + props.aircraft.id}
          className="btn btn-primary btn-sm me-1"
        >
          <FontAwesomeIcon icon="fa-solid fa-pen-to-square" />
        </Link>
      </td>
      <td>
        <Link
          to={"/aircraft/edit/" + props.aircraft.id}
          key={props.aircraft.id}
          className="btn btn-primary btn-sm me-1"
        >
          <FontAwesomeIcon icon="fa-solid fa-pen-to-square" />
        </Link>
      </td>
      <td>
        <Button variant="outline-secondary" size="sm">
          <FontAwesomeIcon icon="fa-solid fa-trash-can" />
        </Button>
      </td>
    </tr>
  );
}

export { List };
