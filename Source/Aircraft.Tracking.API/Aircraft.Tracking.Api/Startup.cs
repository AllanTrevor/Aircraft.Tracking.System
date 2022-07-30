using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Rusada.Core.Data;
using Aircraft.Tracking.Services;
using Aircraft.Tracking.DataAccess.Dapper;
using Aircraft.Tracking.Core.Services;
using Aircraft.Tracking.Core;
using Aircraft.Tracking.Core.Common;
using Aircraft.Tracking.Api.Common;
using Aircraft.Tracking.Core.Utility;
using Rusada.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using Rusada.Core.Data.EF;
using Aircraft.Tracking.Services.EF;
using System;

namespace Aircraft.Tracking.Api
{
    public class Startup
    {
        public string ContentRootPath { get; }

        public Startup(IHostEnvironment env)
        {
            ContentRootPath = env.ContentRootPath;
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            string reactWebServerUrl = Configuration["WebServers:ReactWebServer:Url"];
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins(reactWebServerUrl);
                        policy.AllowAnyMethod();
                        policy.AllowAnyHeader();
                    });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aircraft.Tracking.Api", Version = "v1" });
            });

            services.AddTransient<IAircraftTrackerAPIResponse, AircraftTrackerAPIResponse>();

            services.AddTransient<IAircraftTrackerResponse, AircraftTrackerResponse>();

            //Dapper
            services.AddTransient<IAircraftTrackingUnitOfWork, AircraftTrackingUnitOfWork>(ctx =>
            {
                IConnectionFactory connectionFactory = new AircraftTrackerConnectionFactory(Configuration.GetConnectionString("SqlConnectionString"));
                return new AircraftTrackingUnitOfWork(connectionFactory);
            });

            services.AddTransient<IAircraftInformationService, AircraftInformationService>();

            //EF
            services.AddTransient<IAircraftRepository, AircraftRepository>();
            services.AddTransient<IAircraftUnitOfWork, AircraftUnitOfWork>();
            services.AddTransient<IAircraftService, AircraftService>();
            services.AddDbContext<AircraftDbContext>(options => options.UseSqlServer(
                    Configuration.GetConnectionString("EFSqlConnectionString")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aircraft Tracking API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aircraft.Tracking.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
