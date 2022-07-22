using System;
using System.ComponentModel.DataAnnotations;
using Aircraft.Tracking.Core.Poco;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;


namespace Aircraft.Tracking.Core.Models
{
    public class AircraftInformationModels
    {		
		public AircraftInformation AircraftInformation { get; set; }

		[Write(false)]
		public string Base64AircraftImage { get; set; }
	}

}
