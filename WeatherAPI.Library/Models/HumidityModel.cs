using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Library.Models
{
    public class HumidityModel
    {
        public int Id { get; set; }
        public int ReadingId { get; set; }
        public int Humidity { get; set; }
    }
}
