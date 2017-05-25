using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WeatherForecast.Model.DarkSky
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

    [DebuggerDisplay("{Timezone}, {Currently}")]
    public class WeatherData
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Timezone { get; set; }
        public DataPoint Currently { get; set; }
    }
}
