using System.Collections.Generic;

namespace Aircraft.Tracking.Api.Common
{
    public class AircraftTrackerResponse : IAircraftTrackerResponse
    {
        public string SuccessString = string.Empty;
        public string ErrorString = string.Empty;
        public string LockedMessage = string.Empty;
        public string Result { get; set; }
        public object Data { get; set; }


		public AircraftTrackerResponse GenerateResponseMessage(string successString, string errorString, string lockedMessage, string result, Dictionary<string, object> dattaHoldDictionary)
		{
			this.SuccessString = successString;
			this.ErrorString = errorString;
			this.LockedMessage = lockedMessage;
			this.Data = dattaHoldDictionary;

			return this;
		}

		public AircraftTrackerResponse GenerateResponseMessage(string successString, string errorString, string lockedMessage, string result, object data)
		{
			this.SuccessString = successString;
			this.ErrorString = errorString;
			this.LockedMessage = lockedMessage;
			this.Data = data;

			return this;
		}


	}
}
