using System;
using WeatherForecast.Model.DarkSky;
using WeatherForecast.Model.GeoNames;

namespace WeatherForecast.Model
{
    public static class ServiceFactory
    {
        public static IForecastReader GetForecastReader()
        {
            var reader = new KeyReader("forecast.key");
            return new ForecastReader(reader.DarkSkyKey);
        }

        public static ILocationReader GeLocationReader()
        {
            var reader = new KeyReader("forecast.key");
            return new LocationReader(reader.GeoNamesKey);
        }
    }
}
