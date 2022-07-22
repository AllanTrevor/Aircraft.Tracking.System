using Dapper.Contrib.Extensions;

using Rusada.Core.Data;
using Aircraft.Tracking.Core.Poco;
using System;

namespace Aircraft.Tracking.DataAccess.Dapper
{
	public static class AircraftInformationRepository
	{

		public static bool SaveAircraftInformation(this IRepository<AircraftInformation> repository, AircraftInformation aircraftInformation)
		{
			bool result = false;
			using (var connection = repository.GetConnectionFactory().GetConnection())
			{
				connection.Open();
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						long Id = connection.Insert(aircraftInformation);
						aircraftInformation.Id = (int)Id;
						if (Id > 0)
						{
							result = true;

						}

					}
					catch (Exception ex)
					{
						//throw ex;
						return result;
					}
				}

				return result;

			}


			//public static AircraftInformation Get(this IRepository<AircraftInformation> repository, int id)
			//      {
			//          using (var connection = repository.GetConnectionFactory().GetConnection())
			//          {
			//              connection.Open();
			//              return connection.Get<AircraftInformation>(id);
			//          }
			//      }

		}
	}
}
