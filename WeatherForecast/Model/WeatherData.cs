using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model
{
    public enum WeatherIcon
    {
        None,
        ClearDay,
        ClearNight,
        Rain,
        Snow,
        Sleet,
        Wind,
        Fog,
        Cloudy,
        PartlyCloudyDay,
        PartlyCloudyNight
    }

    public class WeatherData
    {
        public int Temperature { get; set; }
        public int Pressure { get; set; }
        public string Summary { get; set; }
        public WeatherIcon Icon { get; set; }
    }
}
