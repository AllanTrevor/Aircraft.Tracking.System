using Aircraft.Tracking.Core.Poco;
using Rusada.Core.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.DataAccess.EF
{
    public class AircraftRepository : GenericRepository<AircraftInformation>, IAircraftRepository
    {
        public AircraftRepository(AircraftDbContext context) : base(context)
        {
        }

        public AircraftDbContext AircraftDbContext => context as AircraftDbContext;
    }
}
