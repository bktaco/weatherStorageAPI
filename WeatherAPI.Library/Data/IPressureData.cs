using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public interface IPressureData
    {
        Task<List<PressureModel>> GetLatestPressure();
        Task<List<PressureModel>> GetPressureByReadingID(int reading_Id);
    }
}