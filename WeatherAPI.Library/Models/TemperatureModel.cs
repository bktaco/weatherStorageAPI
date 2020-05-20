using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Library.Models
{
    public class TemperatureModel
    {
        public int Id { get; set; }
        public int ReadingId { get; set; }
        public float Temperature { get; set; }
        public float Feels_Like { get; set; }
        public float Temp_Min { get; set; }
        public float Temp_Max { get; set; }
    }
}
