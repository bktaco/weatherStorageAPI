using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Library.Db;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public class WeatherReportData : IWeatherReportData
    {
        private readonly IDataAccess _dataAccess;
        private readonly IReadingData _readingData;
        private readonly ConnectionStringData _connectionString;

        public WeatherReportData(IDataAccess dataAccess, IReadingData readingData, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _readingData = readingData;
            _connectionString = connectionString;
        }

        public void Create(WeatherReportModel weatherReport)
        {
            ReadingModel reading = weatherReport.Reading;
            TemperatureModel temperature = weatherReport.Temperature;
            WindModel wind = weatherReport.Wind;
            HumidityModel humidity = weatherReport.Humidity;
            PressureModel pressure = weatherReport.Pressure;
            ConditionModel condition = weatherReport.Condition;

            _dataAccess.SaveData("spReading_SaveNew", reading, _connectionString.MySqlConnectionName);

            var newReading = _readingData.GetLatestReading();

            temperature.ReadingId = newReading.Result[0].Id;
            wind.ReadingId = newReading.Result[0].Id;
            humidity.ReadingId = newReading.Result[0].Id;
            pressure.ReadingID = newReading.Result[0].Id;
            condition.ReadingId = newReading.Result[0].Id;

            _dataAccess.SaveData("spTemperature_SaveNew", temperature, _connectionString.MySqlConnectionName);
            _dataAccess.SaveData("spWind_SaveNew", wind, _connectionString.MySqlConnectionName);
            _dataAccess.SaveData("spHumidity_SaveNew", humidity, _connectionString.MySqlConnectionName);
            _dataAccess.SaveData("spPressure_SaveNew", pressure, _connectionString.MySqlConnectionName);
            _dataAccess.SaveData("spCondition_SaveNew", condition, _connectionString.MySqlConnectionName);
        }
    }
}
