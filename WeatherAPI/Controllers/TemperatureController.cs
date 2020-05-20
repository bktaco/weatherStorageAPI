using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Library.Data;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ITemperatureData _temperatureData;

        public TemperatureController(ITemperatureData temperatureData)
        {
            _temperatureData = temperatureData;
        }

        public async Task<TemperatureModel> Get()
        {
            var reading = await _temperatureData.GetLatestTemperature();

            TemperatureModel currentTemp = new TemperatureModel
            {
                Id = reading.FirstOrDefault().Id,
                ReadingId = reading.FirstOrDefault().ReadingId,
                Temperature = reading.FirstOrDefault().Temperature,
                Feels_Like = reading.FirstOrDefault().Feels_Like,
                Temp_Min = reading.FirstOrDefault().Temp_Min,
                Temp_Max = reading.FirstOrDefault().Temp_Max
            };
            
            return currentTemp;
        }
    }
}