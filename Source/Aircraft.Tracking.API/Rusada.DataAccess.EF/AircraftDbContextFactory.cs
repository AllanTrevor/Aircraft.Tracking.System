using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Rusada.DataAccess.EF
{
    public class AircraftDbContextFactory : IDesignTimeDbContextFactory<AircraftDbContext>
    {
        public AircraftDbContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();

            DbContextOptionsBuilder<AircraftDbContext> optionsBuilder = new DbContextOptionsBuilder<AircraftDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("EFSqlConnectionString"));

            return new AircraftDbContext(optionsBuilder.Options);
        }
    }
}
