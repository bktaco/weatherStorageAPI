using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Library.Db;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public class ConditionData : IConditionData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public ConditionData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<ConditionModel>> GetLatestCondition()
        {
            return _dataAccess.LoadData<ConditionModel, dynamic>("spCondition_GetLatest", new { }, _connectionString.MySqlConnectionName);
        }
        public Task<List<ConditionModel>> GetConditionByReadingID(int reading_Id)
        {
            return _dataAccess.LoadData<ConditionModel, dynamic>("spCondition_GetByReadingID", new { reading_Id }, _connectionString.MySqlConnectionName);
        }
    }
}
