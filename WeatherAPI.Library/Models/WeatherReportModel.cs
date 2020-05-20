using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Library.Models
{
    public class WeatherReportModel
    {
        public ReadingModel Reading { get; set; }
        public TemperatureModel Temperature { get; set; }
        public WindModel Wind { get; set; }
        public HumidityModel Humidity { get; set; }
        public PressureModel Pressure { get; set; }
        public ConditionModel Condition { get; set; }
    }
}
