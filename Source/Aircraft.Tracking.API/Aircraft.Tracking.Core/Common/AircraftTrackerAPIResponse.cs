using System.Collections.Generic;

namespace Aircraft.Tracking.Core.Common
{
    public class AircraftTrackerAPIResponse : IAircraftTrackerAPIResponse
    {

		public string StatusCode = string.Empty;
		public string Message = string.Empty;
		//public string LockedMessage = string.Empty;
		//public string Result { get; set; }
		public object Data { get; set; }

		public AircraftTrackerAPIResponse GenerateResponseMessage(string statusCode, string message, Dictionary<string, object> dataHoldDictionary)
		{
			this.StatusCode = statusCode;
			this.Message = message;
			this.Data = dataHoldDictionary;

			return this;
		}

		public AircraftTrackerAPIResponse GenerateResponseMessage(string statusCode, string message, object data)
		{
			this.StatusCode = statusCode;
			this.Message = message;
			this.Data = data;

			return this;
		}

	}
}
