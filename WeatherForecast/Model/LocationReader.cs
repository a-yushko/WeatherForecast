using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model
{
    /// <summary>
    /// Finds location using GeoNames webservice
    /// See http://www.geonames.org/export/geonames-search.html
    /// </summary>
    /// <example>http://api.geonames.org/search?name_startsWith=%D0%9A%D0%B8%D1%97%D0%B2&username=demo
    /// http://api.geonames.org/searchJSON?q=london&maxRows=10&username=demo
    /// </example>
    public class LocationReader : ILocationReader
    {
        public Task<IEnumerable<Location>> FindLocationAsync(string name)
        {
            return Task.FromResult(GetDummyData());
        }

        private IEnumerable<Location> GetDummyData()
        {
            return new List<Location>()
            {
                new Location() {Timezone = "Europe/Kiev"},
                new Location() {Timezone = "Europe/Lviv"},
                new Location() {Timezone = "Asia/Beijing"}
            };
        }
    }
}
