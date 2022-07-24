using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

namespace Aircraft.Tracking.Core.Poco
{
    [Table("AircraftInformation")]
    public class AircraftInformation
    {
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(128)]
		public string Make { get; set; }
		[Required]
		[StringLength(128)]
		public string Model { get; set; }
		[Required]
		[StringLength(8)]
		public string Registration { get; set; }
		[Required]
		[StringLength(255)]
		public string Location { get; set; }

		public int CreatedBy { get; set; }
		
		public DateTime CreatedDate { get; set; }

		[HistoryDateAttribute(ErrorMessage = "Date Must Be in Past")]
		public DateTime SpottedOn { get; set; }

		public int? ModifiedBy { get; set; }

		public DateTime? ModifiedDate { get; set; }

		public bool IsActive { get; set; }

		public string AircraftImage { get; set; }

	}

	public class HistoryDateAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			DateTime _dateStart = Convert.ToDateTime(value);
			if (_dateStart < DateTime.Now)
			{
				return ValidationResult.Success;
			}
			else
			{
				return new ValidationResult(ErrorMessage);
			}
		}
	}
}
