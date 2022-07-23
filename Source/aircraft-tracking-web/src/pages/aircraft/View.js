import React, { useState, useEffect } from "react";
import {
  BrowserRouter as Router,
  useParams,
} from "react-router-dom";

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
    <div>
      {loading && <h1>Loading...</h1>}
      {(!loading && aircraft) && <div className="container-fluid">
        <h2>View {aircraft.registration}</h2>
      </div>}
      
    </div>
  );
}
export default View;
