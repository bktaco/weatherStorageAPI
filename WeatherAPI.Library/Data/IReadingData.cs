using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public interface IReadingData
    {
        Task<List<ReadingModel>> GetLatestReading();
    }
}