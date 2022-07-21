using System.Data;
using System.Data.SqlClient;

using Rusada.Core.Data;

namespace Aircraft.Tracking.DataAccess.Dapper
{
	public class AircraftTrackerConnectionFactory : IConnectionFactory
    {

		private readonly string connectionString;

		public AircraftTrackerConnectionFactory(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public IDbConnection GetConnection()
		{
			return new SqlConnection(this.connectionString);
		}

	}
}
