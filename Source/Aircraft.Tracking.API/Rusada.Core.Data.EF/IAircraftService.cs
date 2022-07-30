using Aircraft.Tracking.Core.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Core.Data.EF
{
	public interface IAircraftService
	{
        AircraftInformation Get(int id);
        Task<AircraftInformation> GetAsync(int id);

        IEnumerable<AircraftInformation> GetAll(ActiveStatusEnum activeStatusEnum);

        AircraftInformation Insert(AircraftInformation entity);

        AircraftInformation Update(AircraftInformation entity);

        void Delete(AircraftInformation entity);
    }
}
