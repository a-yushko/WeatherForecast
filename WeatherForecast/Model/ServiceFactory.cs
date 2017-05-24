using System;
using System.Collections.Generic;
using System.IO;

namespace WeatherForecast.Model
{
    public static class ServiceFactory
    {
        public static IForecastReader GetForecastReader()
        {
            try
            {
                var key = File.ReadAllText("key.txt");
                return new DarkSkyForecastReader(key.Trim());
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
            return new LocationReader();
        }
    }
}
