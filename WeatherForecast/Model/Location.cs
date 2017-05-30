using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WeatherForecast.Model
{
    [DebuggerDisplay("{Latitude}, {Longitude}")]
    public class Location
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Timezone { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string AdministrativeName { get; set; }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
