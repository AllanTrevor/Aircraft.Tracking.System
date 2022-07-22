using System.Collections.Generic;
using Aircraft.Tracking.Core.Models;
using Aircraft.Tracking.Core.Poco;
using Microsoft.AspNetCore.Http;
using Rusada.Core.Data;

namespace Aircraft.Tracking.Core.Services
{
    public interface IAircraftInformationService : IService<AircraftInformation>
    {
        IEnumerable<AircraftInformation> GetAll(ActiveStatusEnum activeStatusEnum);
        bool SaveAircraftInformation(AircraftInformationModels aircraftInformationModels, HttpContext httpContext);
    }
}
