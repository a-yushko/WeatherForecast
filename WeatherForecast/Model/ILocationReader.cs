using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model
{
    public interface ILocationReader
    {
        Task<IEnumerable<Location>> FindLocationAsync(string name);
    }
}
