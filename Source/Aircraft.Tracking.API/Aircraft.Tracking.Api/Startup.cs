
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

namespace Aircraft.Tracking.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
            services.AddMvc();

            //services.AddAutoMapper();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);


            services.AddControllers();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aircraft.Tracking.Api", Version = "v1" });
            });

            services.AddTransient<IAircraftTrackerResponse, AircraftTrackerResponse>();

            
            services.AddTransient<IAircraftTrackingUnitOfWork, AircraftTrackingUnitOfWork>(ctx =>
            {
                IConnectionFactory connectionFactory = new AircraftTrackerConnectionFactory(Configuration.GetConnectionString("SqlConnectionString"));
                return new AircraftTrackingUnitOfWork(connectionFactory);
            });

            services.AddTransient<IAircraftTrackerAPIResponse, AircraftTrackerAPIResponse>();

            services.AddTransient<IAircraftInformationService, AircraftInformationService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            string reactWebServerUrl = Configuration["WebServers:ReactWebServer:Url"];
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
                 builder.WithOrigins(reactWebServerUrl).AllowAnyHeader().AllowAnyMethod());

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
