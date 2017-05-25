using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WeatherForecast.Model.GeoNames
{
    [DebuggerDisplay("{Name}, {CountryName}")]
    public struct Geoname
    {
        public int GeonameId;
        public string ToponymName;
        public int CountryId;
        // Feature class
        public char Fcl;
        public int Population;
		public string CountryCode;
        public string Name;
        public string FclName;
        public string CountryName;
        public string AdminCode1;
        public string AdminName1;
        public float Lng;
        public float Lat;
        public string Fcode;
        public string FcodeName;
    }
}
