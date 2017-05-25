using System;
using System.Collections.Generic;
using System.IO;
using WeatherForecast.Model.DarkSky;
using WeatherForecast.Model.GeoNames;

namespace WeatherForecast.Model
{
    public static class ServiceFactory
    {
        public static IForecastReader GetForecastReader()
        {
            try
            {
                var key = File.ReadAllText("key.txt");
                return new ForecastReader(key.Trim());
            }
            catch (IOException e)
            {
                throw new InvalidOperationException("Could not read the key file", e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new InvalidOperationException("Do not have the required permission to access key file", e);
            }
        }

        public static ILocationReader GeLocationReader()
        {
            var key = File.ReadAllText("user.txt");           
            return new LocationReader(key.Trim());
        }
    }
}
