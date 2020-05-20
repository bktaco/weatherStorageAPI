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
    public class HumidityController : ControllerBase
    {
        private readonly IHumidityData _humidityData;

        public HumidityController(IHumidityData humidityData)
        {
            _humidityData = humidityData;
        }

        public async Task<HumidityModel> Get()
        {
            var reading = await _humidityData.GetLatestHumidity();

            HumidityModel currentHumidity = new HumidityModel
            {
                Id = reading.FirstOrDefault().Id,
                ReadingId = reading.FirstOrDefault().ReadingId,
                Humidity = reading.FirstOrDefault().Humidity
            };

            return currentHumidity;
        }
    }
}