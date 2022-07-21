using System;
using Dapper.Contrib.Extensions;

namespace Aircraft.Tracking.Core.Poco
{
    [Table("AircraftInformation")]
    public class AircraftInformation
    {
		[Key]
		public int Id { get; set; }

		public string Make { get; set; }

		public string Model { get; set; }

		public string Registration { get; set; }

		public string Location { get; set; }

		public int CreatedBy { get; set; }

		public DateTime CreatedDate { get; set; }

		public int? ModifiedBy { get; set; }

		public DateTime? ModifiedDate { get; set; }

		public bool IsActive { get; set; }

		//public byte[] AircraftImage { get; set; }

	}
}
