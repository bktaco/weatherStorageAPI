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
    public class WindController : ControllerBase
    {
        private readonly IWindData _windData;

        public WindController(IWindData windData)
        {
            _windData = windData;
        }

        public async Task<WindModel> Get() 
        {
            var windReading = await _windData.GetLatestWind();

            WindModel currentWind = new WindModel
            {
                Id = windReading.FirstOrDefault().Id,
                ReadingId = windReading.FirstOrDefault().ReadingId,
                Wind_Speed = windReading.FirstOrDefault().Wind_Speed,
                Wind_Direction = windReading.FirstOrDefault().Wind_Direction
            };

            return currentWind;
        }
    }
}