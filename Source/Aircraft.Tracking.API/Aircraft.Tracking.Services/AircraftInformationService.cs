using System.Collections.Generic;
using System.Linq;

using Rusada.Core.Data;
using Aircraft.Tracking.Core;
using Aircraft.Tracking.Core.Services;
using Aircraft.Tracking.Core.Poco;
using Aircraft.Tracking.Core.Models;
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

        public bool SaveAircraftInformation(AircraftInformationModels aircraftInformationModels, HttpContext httpContext)
        {
            //teamModel.Team.CreatedByName = createdByName;
            var result = this.unitOfWork.Repository<AircraftInformation>().SaveAircraftInformation(aircraftInformationModels.AircraftInformation);

            //auditData.Data = teamModel.Team.Code + '-' + teamModel.Team.Name;
            //if (auditData.Result)
            //{
            //    auditService.CreateAuditLog(0, ActionTypeEnum.Create.ToString(), auditData, httpContext, createdByName);
            //}
            return result;
        }
    }
}
