using System.Collections.Generic;
using System.Linq;

using Rusada.Core.Data;
using Aircraft.Tracking.Core;
using Aircraft.Tracking.Core.Services;
using Aircraft.Tracking.Core.Poco;
using Microsoft.AspNetCore.Http;
using Aircraft.Tracking.DataAccess.Dapper;

namespace Aircraft.Tracking.Services
{
    public class AircraftInformationService : Service<AircraftInformation>, IAircraftInformationService
    {
        IAircraftTrackingUnitOfWork unitOfWork;

        public AircraftInformationService(IAircraftTrackingUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }

        public IEnumerable<AircraftInformation> GetAll(ActiveStatusEnum activeStatusEnum)
        {
			IEnumerable<AircraftInformation> result;
			if (activeStatusEnum == ActiveStatusEnum.Active)
			{
				result = GetAll().Where(x => x.IsActive == true);
			}
			else if (activeStatusEnum == ActiveStatusEnum.Inactive)
			{
				result = GetAll().Where(x => x.IsActive == false);
			}
			else
			{
				result = GetAll();
			}
			return result;
		}


    }
}
