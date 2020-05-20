using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Library.Models
{
    public class PressureModel
    {
        public int Id { get; set; }
        public int ReadingID { get; set; }
        public int Pressure { get; set; }
    }
}
