using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Library.Db;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public class HumidityData : IHumidityData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public HumidityData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<HumidityModel>> GetLatestHumidity()
        {
            return _dataAccess.LoadData<HumidityModel, dynamic>("spHumidity_GetLatest", new { }, _connectionString.MySqlConnectionName);
        }

        public Task<List<HumidityModel>> GetHumidityByReadingID(int reading_Id)
        {
            return _dataAccess.LoadData<HumidityModel, dynamic>("spHumidity_GetByReadingID", new { reading_Id }, _connectionString.MySqlConnectionName);
        }
    }
}
