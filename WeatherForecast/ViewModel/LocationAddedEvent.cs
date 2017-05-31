using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.ViewModel
{
    public class LocationAddedEvent
    {
        public LocationViewModel Location { get; set; }
    }
}
