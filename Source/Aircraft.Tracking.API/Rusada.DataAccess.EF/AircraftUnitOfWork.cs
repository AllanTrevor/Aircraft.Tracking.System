using Aircraft.Tracking.Core.Poco;
using Rusada.Core.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.DataAccess.EF
{
    public class AircraftUnitOfWork : IAircraftUnitOfWork
    {
        private readonly AircraftDbContext context;

        public IAircraftRepository Aircrafts { get; }


        public AircraftUnitOfWork(AircraftDbContext context,
            IAircraftRepository aircrafts)
        {
            this.context = context;
            Aircrafts = aircrafts;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Complete()
        {
            context.SaveChanges();
        }

        public async Task BeginTransactionAsync()
        {
            await context.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            context.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            context.RollbackTransaction();
        }

    }
}
