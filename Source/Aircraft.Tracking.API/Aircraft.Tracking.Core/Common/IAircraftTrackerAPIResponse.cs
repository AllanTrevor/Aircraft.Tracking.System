using System.Collections.Generic;

namespace Aircraft.Tracking.Core.Common
{
    public interface IAircraftTrackerAPIResponse
    {

        AircraftTrackerAPIResponse GenerateResponseMessage(string statusCode, string message, Dictionary<string, object> dattaHoldDictionary);
        //web
        AircraftTrackerAPIResponse GenerateResponseMessage(string statusCode, string message, object data);


    }
}
