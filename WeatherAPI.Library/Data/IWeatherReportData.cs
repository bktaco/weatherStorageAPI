using WeatherAPI.Library.Models;

namespace WeatherAPI.Library.Data
{
    public interface IWeatherReportData
    {
        void Create(WeatherReportModel weatherReport);
    }
}