using System;

namespace WeatherForecast.Model
{
    public interface IForecastReader
    {
        WeatherData ReadData(Location location);
    }

    /// <summary>
    /// Reads heater using Dark Sky API
    /// </summary>
    /// <remarks>
    /// See https://darksky.net/dev/docs
    /// </remarks>
    public class ForecastReader : IForecastReader
    {
        // API secret key
        private string key;

        public ForecastReader(string key)
        {
            this.key = key;
        }
        public WeatherData ReadData(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
