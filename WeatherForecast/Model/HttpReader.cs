using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model
{
    public abstract class HttpReader
    {
        protected HttpClient Reader = new HttpClient();

        protected void Init()
        {
            Reader.BaseAddress = GetBaseAddress();
        }

        public abstract Uri GetBaseAddress();

        public abstract string GetRequestString(object arg);

        /// <summary>
        /// Send a GET request
        /// </summary>
        public Task<HttpResponseMessage> GetAsync(object arg)
        {
            return Reader.GetAsync(GetRequestString(arg));
        }

    }
}
