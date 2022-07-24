import { Link } from "react-router-dom";

import { Button, Stack } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Moment from "react-moment";

export default function List(props) {
  const { aircraft, deleteAircraft } = props;

  const deleteAircraftHandler = (id) => {
    if (typeof deleteAircraft === "function" && id && id > 0) {
      deleteAircraft(id);
    }
  };

  return (
    <tr key={aircraft.id}>
      <td>{aircraft.registration}</td>
      <td>{aircraft.make}</td>
      <td>{aircraft.model}</td>
      <td>{aircraft.location}</td>
      <td>
        <Moment local>{aircraft.spottedOn}</Moment>
      </td>
      <td>
        <Stack direction="horizontal" gap={0}>
          <Link
            title="View"
            to={"/aircraft/view/" + aircraft.id}
            className="btn btn-primary btn-sm me-1"
          >
            <FontAwesomeIcon icon="fa-solid fa-eye" />
          </Link>
          <Link
            title="Edit"
            to={"/aircraft/edit/" + aircraft.id}
            key={aircraft.id}
            className="btn btn-primary btn-sm me-1"
          >
            <FontAwesomeIcon icon="fa-solid fa-pen-to-square" />
          </Link>
          <Button
            title="Delete"
            variant="danger"
            value={aircraft.id}
            size="sm"
            onClick={() => deleteAircraftHandler(aircraft.id)}
          >
            <FontAwesomeIcon icon="fa-solid fa-trash-can" />
          </Button>
        </Stack>
      </td>
    </tr>
  );
}

export { List };
