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
    public class PressureController : ControllerBase
    {
        private readonly IPressureData _pressureData;

        public PressureController(IPressureData pressureData)
        {
            _pressureData = pressureData;
        }

        public async Task<PressureModel> Get()
        {
            var reading = await _pressureData.GetLatestPressure();

            PressureModel currentPressure = new PressureModel
            {
                Id = reading.FirstOrDefault().Id,
                ReadingID = reading.FirstOrDefault().ReadingID,
                Pressure = reading.FirstOrDefault().Pressure
            };

            return currentPressure;
        }
    }
}