using System.Collections.Generic;


namespace Aircraft.Tracking.Api.Common
{
    public interface IAircraftTrackerResponse
    {

        AircraftTrackerResponse GenerateResponseMessage(string successString, string errorString, string lockedMessage, string result, Dictionary<string, object> dattaHoldDictionary);

        AircraftTrackerResponse GenerateResponseMessage(string successString, string errorString, string lockedMessage, string result, object dattaHoldDictionary);

    }
}
