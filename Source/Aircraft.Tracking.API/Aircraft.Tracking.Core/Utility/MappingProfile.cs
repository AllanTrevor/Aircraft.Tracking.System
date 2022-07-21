using System;


using System.Globalization;

using AutoMapper;

using Aircraft.Tracking.Core.Poco;
using Aircraft.Tracking.Core.Common;

namespace Aircraft.Tracking.Core.Utility
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<AircraftTrackerAPIResponse, AircraftInformation>()
               .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => DateTime.ParseExact(x.Message.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture)))
               .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(x => DateTime.ParseExact(x.Data.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture)));

        }
    }
}
