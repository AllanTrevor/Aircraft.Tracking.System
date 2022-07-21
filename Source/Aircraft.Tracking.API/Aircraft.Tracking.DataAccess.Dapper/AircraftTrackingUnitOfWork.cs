
using Rusada.Core.Data;
using Rusada.DataAccess.Dapper;
using Aircraft.Tracking.Core;

namespace Aircraft.Tracking.DataAccess.Dapper
{
    public class AircraftTrackingUnitOfWork : UnitOfWork , IAircraftTrackingUnitOfWork
    {

        public AircraftTrackingUnitOfWork(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            //MapTableNames();
        }
    }
}
