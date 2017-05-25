using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model.GeoNames
{
    public class GeonameInfo
    {
        public int TotalResultsCount { get; set; }
        public List<Geoname> Geonames { get; set; }
    }
}
