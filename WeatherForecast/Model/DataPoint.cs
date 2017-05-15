using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model
{
    public class DataPoint
    {
        public int Time { get; set; }
        public string Summary { get; set; }
        public WeatherIcon Icon { get; set; }
        public float Humidity { get; set; }
        public float Temperature { get; set; }
        public float ApparentTemperature { get; set; }
        public float DewPoint { get; set; }
        public float Pressure { get; set; }
    }
}
