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


        public LocationViewModel(Location location)
            : this(new WeatherData()
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Timezone = location.Timezone
                })
        {
        }

        public LocationViewModel(WeatherData data)
        {
            _data = data;
        }

        public Location Location
        {
            get
            {
                return new Location()
                {
                    Latitude = _data?.Latitude,
                    Longitude = _data?.Longitude,
                    Timezone = _data?.Timezone
                };
            }
        }

        public string City => _data.Timezone.ToUpper();

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
    }
}
