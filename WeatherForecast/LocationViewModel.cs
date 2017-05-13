using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Model;

namespace WeatherForecast
{
    public class LocationViewModel
    {
        public LocationViewModel(Location location, WeatherData forecast)
        {
            Location = location;
            Forecast = forecast;
        }
        public Location Location { get; set; }
        public WeatherData Forecast { get; set; }
    }
}
