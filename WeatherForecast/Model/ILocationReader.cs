using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model
{
    interface ILocationReader
    {
        Task<Location> FindLocationAsync(string name);
    }
}
