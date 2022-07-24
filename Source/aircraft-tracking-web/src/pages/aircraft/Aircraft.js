import React, { useState, useEffect } from "react";
import { BrowserRouter as Router, useParams } from "react-router-dom";

import ApiService from "../../api/Api.service.js";

function Aircraft() {
  const [aircraft, setAircraft] = useState();
  const [loading, setLoading] = useState(false);

  let { id } = useParams();

  useEffect(() => {
    const testApi = async (id) => {
      try {
        setLoading(true);
        const aircraftData = await ApiService.httpGet("/GetById/" + id);
        setAircraft(aircraftData);
        setLoading(false);
      } catch (err) {
        setLoading(false);
      }
    };

    testApi(id);
  }, [id]);

  return (
    <div>
      {loading && (
        // <h1>Loading...</h1>
        
          <div className="progress">
            <div className="progress-bar w-75"></div>
          </div>
        
      )}
      {!loading && aircraft && (
        <div className="container-fluid">
          <h2>{aircraft.registration}</h2>
        </div>
      )}
    </div>
  );
}
export default Aircraft;
