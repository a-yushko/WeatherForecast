using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model
{
    interface ILocationStorage
    {
        AppSettings ReadLocations();
        void SaveLocations(AppSettings settings);
    }
}
