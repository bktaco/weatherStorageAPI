using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public interface IConditionData
    {
        Task<List<ConditionModel>> GetConditionByReadingID(int reading_Id);
        Task<List<ConditionModel>> GetLatestCondition();
    }
}