using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Library.Db;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public class ReadingData : IReadingData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public ReadingData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<ReadingModel>> GetLatestReading()
        {
            return _dataAccess.LoadData<ReadingModel, dynamic>("spReading_LatestReading", new { }, _connectionString.MySqlConnectionName);
        }
    }
}
