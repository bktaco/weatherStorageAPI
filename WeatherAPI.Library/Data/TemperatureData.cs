using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Library.Db;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public class TemperatureData : ITemperatureData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public TemperatureData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<TemperatureModel>> GetLatestTemperature()
        {
            return _dataAccess.LoadData<TemperatureModel, dynamic>("spReading_LatestTemperature", new { }, _connectionString.MySqlConnectionName);
        }

        public Task<List<TemperatureModel>> GetTemperatureByReadingID(int reading_Id)
        {
            return _dataAccess.LoadData<TemperatureModel, dynamic>("spReading_TemperatureByReadingID", new { reading_Id }, _connectionString.MySqlConnectionName);
        }
    }
}
