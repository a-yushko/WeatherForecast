using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Model;
using WeatherForecast.Model.DarkSky;

namespace WeatherForecast.ViewModel
{
    public class LocationViewModel
    {
        private WeatherData _data;
        private Location _location;


        public LocationViewModel(Location location)
            :this(location, null)
        {
        }

        public LocationViewModel(WeatherData data)
            :this(null, data)
        {
        }

        public LocationViewModel(Location location, WeatherData data)
        {
            _location = location;
            _data = data;
        }

        public void UpdateData(WeatherData data)
        {
            _data = data;
        }

        public Location Location => _location;

        public string City => _location?.Name.ToUpper();

        public int Temperature => (int)_data.Currently.Temperature;

        public int FeelsLike => (int)_data.Currently.ApparentTemperature;

        public string FeelsLikeText => $"Feels like {FeelsLike}°";

        public DateTime Time
        {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(_data.Currently.Time);
                return dateTime;
            }
        }

        public DataPoint Current => _data?.Currently;
        public override bool Equals(object obj)
        {
            LocationViewModel other = obj as LocationViewModel;
            if (other == null)
                return base.Equals(obj);
            return other.Location.Equals(_location);
        }

        public override int GetHashCode()
        {
            return 13 + _location.GetHashCode()*7 + _data.GetHashCode();
        }
    }
}
