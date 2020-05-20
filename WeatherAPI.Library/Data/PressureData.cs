using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Library.Db;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public class PressureData : IPressureData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public PressureData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<PressureModel>> GetLatestPressure()
        {
            return _dataAccess.LoadData<PressureModel, dynamic>("spPressure_GetLatest", new { }, _connectionString.MySqlConnectionName);
        }
        public Task<List<PressureModel>> GetPressureByReadingID(int reading_Id)
        {
            return _dataAccess.LoadData<PressureModel, dynamic>("spPressure_GetByReadingID", new { reading_Id }, _connectionString.MySqlConnectionName);
        }
    }
}
