using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Model;

namespace WeatherForecast
{
    public class LocationViewModel
    {
        private WeatherData _data;

        public LocationViewModel(WeatherData data)
        {
            _data = data;
        }

        public string City => _data.Timezone.ToUpper();

        public int Temperature => (int)_data.Currently.Temperature;

        public DataPoint Current => _data.Currently;
    }
}
