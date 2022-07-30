using Aircraft.Tracking.Core.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rusada.DataAccess.EF
{
    public class AircraftDbContext : DbContext
    {

        public AircraftDbContext(DbContextOptions<AircraftDbContext> options) : base(options)
        {
        }

        public DbSet<AircraftInformation> AircraftInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Using IDesignTimeDbContextFactory Class (AircraftDbContextFactory) instead of injecting hard coded Connection String like bellow.
            //optionsBuilder.UseSqlServer("Data Source=TREVORG-LTP\\MSSQLSERVER12;  Initial Catalog=AircraftTrackerEF; User ID=sa; PASSWORD=abcd@1234; Pooling=true; Min Pool Size=5; MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AircraftInformation>(e =>
            {
                e.HasKey(f => f.Id);
                e.Property(p => p.Registration).IsRequired();
                e.Property(p => p.Make).IsRequired();
                e.Property(p => p.Model).IsRequired();
                e.Property(p => p.Location).IsRequired();
                e.Property(p => p.SpottedOn).IsRequired();
                e.Property(p => p.AircraftImage).IsRequired();
            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync()
        {
            await Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            Database.RollbackTransaction();
        }
    }
}
