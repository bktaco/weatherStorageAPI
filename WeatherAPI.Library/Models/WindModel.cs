using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Library.Models
{
    public class WindModel
    {
        public int Id { get; set; }
        public int ReadingId { get; set; }
        public float Wind_Speed { get; set; }
        public int Wind_Direction { get; set; }
    }
}
