using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public interface IWindData
    {
        Task<List<WindModel>> GetLatestWind();
        Task<List<WindModel>> GetWindByReadingID(int reading_Id);
    }
}