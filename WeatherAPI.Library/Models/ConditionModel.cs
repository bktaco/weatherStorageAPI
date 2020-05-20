using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Library.Models
{
    public class ConditionModel
    {
        public int Id { get; set; }
        public int ReadingId { get; set; }
        public string Weather_Condition { get; set; }
        public string Condition_Description { get; set; }
        public string Icon { get; set; }
    }
}
