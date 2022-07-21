using System.Collections.Generic;
using System.Linq;

using Rusada.Core.Data;
using Aircraft.Tracking.Core;
using Aircraft.Tracking.Core.Services;
using Aircraft.Tracking.Core.Poco;

namespace Aircraft.Tracking.Services
{
    public class AircraftInformationService : Service<AircraftInformation>, IAircraftInformationService
    {
        
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

		//public bool SaveTeam(TeamModel teamModel, HttpContext httpContext, string createdByName)
		//{
		//	teamModel.Team.CreatedByName = createdByName;
		//	AuditLog auditData = this.unitOfWork.Repository<Team>().SaveTeam(teamModel.Team, teamModel.TeamDetailList);
		//	auditData.Data = teamModel.Team.Code + '-' + teamModel.Team.Name;
		//	if (auditData.Result)
		//	{
		//		auditService.CreateAuditLog(0, ActionTypeEnum.Create.ToString(), auditData, httpContext, createdByName);
		//	}
		//	return auditData.Result;
		//}
	}
}
