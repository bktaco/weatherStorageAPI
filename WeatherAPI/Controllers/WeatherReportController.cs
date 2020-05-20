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
    public class WeatherReportController : ControllerBase
    {
        private readonly IReadingData _readingData;
        private readonly ITemperatureData _temperatureData;
        private readonly IWeatherReportData _weatherReportData;
        private readonly IWindData _windData;
        private readonly IHumidityData _humidityData;
        private readonly IPressureData _pressureData;
        private readonly IConditionData _conditionData;

        public WeatherReportController(IReadingData readingData, ITemperatureData temperatureData,
                                       IWeatherReportData weatherReportData, IWindData windData,
                                       IHumidityData humidityData, IPressureData pressureData,
                                       IConditionData conditionData)
        {
            _readingData = readingData;
            _temperatureData = temperatureData;
            _weatherReportData = weatherReportData;
            _windData = windData;
            _humidityData = humidityData;
            _pressureData = pressureData;
            _conditionData = conditionData;
        }

        public async Task<WeatherReportModel> Get()
        {
            WeatherReportModel report = new WeatherReportModel();
            
            var reading = await _readingData.GetLatestReading();
            var temp = await _temperatureData.GetTemperatureByReadingID(reading.FirstOrDefault().Id);
            var wind = await _windData.GetWindByReadingID(reading.FirstOrDefault().Id);
            var humidity = await _humidityData.GetHumidityByReadingID(reading.FirstOrDefault().Id);
            var pressure = await _pressureData.GetPressureByReadingID(reading.FirstOrDefault().Id);
            var condition = await _conditionData.GetConditionByReadingID(reading.FirstOrDefault().Id);

            report.Reading = reading.FirstOrDefault();
            report.Temperature = temp.FirstOrDefault();
            report.Wind = wind.FirstOrDefault();
            report.Humidity = humidity.FirstOrDefault();
            report.Pressure = pressure.FirstOrDefault();
            report.Condition = condition.FirstOrDefault();

            return report;
        }

        [HttpPost]
        public void Post(WeatherReportModel weatherReport)
        {
            _weatherReportData.Create(weatherReport);
        }
    }
}