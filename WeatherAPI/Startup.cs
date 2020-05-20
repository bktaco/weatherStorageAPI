using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherAPI.Library.Data;
using WeatherAPI.Library.Db;

namespace WeatherAPI
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
            services.AddControllers();
            services.AddSingleton(new ConnectionStringData
            {
                MySqlConnectionName = "Default"
            });
            services.AddSingleton<IDataAccess, MySqlDb>();
            services.AddSingleton<IReadingData, ReadingData>();
            services.AddSingleton<ITemperatureData, TemperatureData>();
            services.AddSingleton<IWeatherReportData, WeatherReportData>();
            services.AddSingleton<IWindData, WindData>();
            services.AddSingleton<IHumidityData, HumidityData>();
            services.AddSingleton<IPressureData, PressureData>();
            services.AddSingleton<IConditionData, ConditionData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
