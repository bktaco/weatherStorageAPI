using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public interface IHumidityData
    {
        Task<List<HumidityModel>> GetHumidityByReadingID(int reading_Id);
        Task<List<HumidityModel>> GetLatestHumidity();
    }
}