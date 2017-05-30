using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model.GeoNames
{
    /// <summary>
    /// Finds location using GeoNames webservice
    /// See http://www.geonames.org/export/geonames-search.html
    /// </summary>
    /// <example>http://api.geonames.org/search?name_startsWith=%D0%9A%D0%B8%D1%97%D0%B2&username=demo
    /// http://api.geonames.org/searchJSON?q=london&maxRows=10&username=demo
    /// </example>
    public class LocationReader : HttpReader, ILocationReader
    {
        private string _userName;

        public LocationReader(string userName)
        {
            _userName = userName;
            Init();
            MaxRows = 15;
        }
        public int MaxRows { get; set; }

        public async Task<IEnumerable<Location>> FindLocationAsync(string name)
        {
            if (String.IsNullOrEmpty(name))
                return Enumerable.Empty<Location>();
            var response = await GetAsync(name);
            if (response.IsSuccessStatusCode)
            {
                #if DEBUG
                string json = await response.Content.ReadAsStringAsync();
                #endif
                var data = await response.Content.ReadAsAsync<GeonameInfo>();

                if (data.TotalResultsCount == 0)
                    return Enumerable.Empty<Location>();

                var locations = data.Geonames.Select(it => new Location()
                {
                    Name = it.Name,
                    Country = it.CountryName,
                    AdministrativeName = it.AdminName1,
                    Latitude = it.Lat.ToString(),
                    Longitude = it.Lng.ToString()
                }).ToList();
                return locations;
            }
            return await Task.FromResult(GetDummyData());
        }

        public override Uri GetBaseAddress()
        {
            return new Uri("http://api.geonames.org/searchJSON");
        }

        public override string GetRequestString(object arg)
        {
            var name = arg as string;
            var builder = new StringBuilder();
            builder.AppendFormat("?name_startsWith={0}&featureClass=P&maxRows={1}&cities=cities1000&username={2}", name, MaxRows, _userName);
            return builder.ToString();
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
