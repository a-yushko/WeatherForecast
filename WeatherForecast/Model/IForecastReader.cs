using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Model.DarkSky;

namespace WeatherForecast.Model
{
    public interface IForecastReader
    {
        Task<WeatherData> ReadDataAsync(Location location);
    }
}
