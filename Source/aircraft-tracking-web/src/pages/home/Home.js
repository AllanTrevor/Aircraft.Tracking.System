import React, { useState, useEffect } from "react";
import ListGroup from "react-bootstrap/ListGroup";

import ApiService from "../../api/Api.service.js";

import { List } from "../../components/List.js";

function Home() {
  const [aircrafts, setAircrafts] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const testApi = async () => {
      try {
        setLoading(true);
        const aircraftData = await ApiService.httpGet("/GetAll");
        setAircrafts(aircraftData);
        setLoading(false);
      } catch (err) {
        setLoading(false);
      }
    };

    testApi();
  }, []);

  return (
    <div>
      {loading && <h1>Loading...</h1>}
      <div className="container-fluid">
        <ListGroup>
          {aircrafts.map((aircraft) => {
            return <List key={aircraft.id} aircraft={aircraft}></List>;
          })}
        </ListGroup>
      </div>
    </div>
  );
}

export default Home;
