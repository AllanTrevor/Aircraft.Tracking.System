using Dapper.Contrib.Extensions;

using Rusada.Core.Data;
using Aircraft.Tracking.Core.Poco;

namespace Aircraft.Tracking.DataAccess.Dapper
{
    public static class AircraftInformationRepository
    {
        public static AircraftInformation Get(this IRepository<AircraftInformation> repository, int id)
        {
            using (var connection = repository.GetConnectionFactory().GetConnection())
            {
                connection.Open();
                return connection.Get<AircraftInformation>(id);
            }
        }

    }
}
