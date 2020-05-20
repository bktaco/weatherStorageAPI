using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Library.Db;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public class WindData : IWindData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public WindData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<WindModel>> GetLatestWind()
        {
            return _dataAccess.LoadData<WindModel, dynamic>("spWind_GetLatest", new { }, _connectionString.MySqlConnectionName);
        }

        public Task<List<WindModel>> GetWindByReadingID(int reading_Id)
        {
            return _dataAccess.LoadData<WindModel, dynamic>("spWind_GetByReadingID", new { reading_Id }, _connectionString.MySqlConnectionName);
        }
    }
}
