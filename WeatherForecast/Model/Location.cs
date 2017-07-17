using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WeatherForecast.Model
{
    [DebuggerDisplay("{Latitude}, {Longitude}")]
    [Serializable]
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

        public override bool Equals(object obj)
        {
            Location other = obj as Location;
            if (other == null)
                return base.Equals(obj);
            return String.Equals(Latitude, other.Latitude) && String.Equals(Longitude, other.Longitude)
                   && String.Equals(Name, other.Name) && String.Equals(Country, other.Country);

        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Latitude?.GetHashCode() ?? 0;
            hash = (hash * 7) + Longitude?.GetHashCode() ?? 0;
            hash = (hash * 7) + Name?.GetHashCode() ?? 0;
            hash = (hash * 7) + Country?.GetHashCode() ?? 0;
            return hash;
        }
    }
}
