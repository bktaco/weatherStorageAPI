using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public interface ITemperatureData
    {
        Task<List<TemperatureModel>> GetLatestTemperature();
        Task<List<TemperatureModel>> GetTemperatureByReadingID(int readingId);
    }
}