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
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Timezone { get; set; }
        public DataPoint Currently { get; set; }
    }
}
