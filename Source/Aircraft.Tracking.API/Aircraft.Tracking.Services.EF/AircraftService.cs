using Aircraft.Tracking.Core.Poco;
using Rusada.Core.Data;
using Rusada.Core.Data.EF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aircraft.Tracking.Services.EF
{
    public class AircraftService : IAircraftService
    {
        private readonly IAircraftUnitOfWork aircraftUnitOfWork;

        public AircraftService(IAircraftUnitOfWork aircraftUnitOfWork)
        {
            this.aircraftUnitOfWork = aircraftUnitOfWork;
        }

        public AircraftInformation Get(int id)
        {
            return aircraftUnitOfWork.Aircrafts.Get(id);
        }
        public async Task<AircraftInformation> GetAsync(int id)
        {
            return await aircraftUnitOfWork.Aircrafts.GetAsync(id);
        }

        public IEnumerable<AircraftInformation> GetAll(ActiveStatusEnum activeStatusEnum)
        {
            return aircraftUnitOfWork.Aircrafts.FindAll(x => (activeStatusEnum == ActiveStatusEnum.Active && x.IsActive)
                                                            || (activeStatusEnum == ActiveStatusEnum.Inactive && !x.IsActive)
                                                            || (activeStatusEnum == ActiveStatusEnum.All));
        }

        public AircraftInformation Insert(AircraftInformation entity)
        {
            aircraftUnitOfWork.Aircrafts.Insert(entity);
            aircraftUnitOfWork.Complete();
            return entity;
        }

        public AircraftInformation Update(AircraftInformation entity)
        {
            aircraftUnitOfWork.Aircrafts.Update(entity);
            aircraftUnitOfWork.Complete();
            return entity;
        }

        public void Delete(AircraftInformation entity)
        {
            aircraftUnitOfWork.Aircrafts.Delete(entity);
            aircraftUnitOfWork.Complete();
        }
    }
}
