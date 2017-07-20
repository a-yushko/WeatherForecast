using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model.DarkSky
{
    /// <summary>
    /// Reads heater using Dark Sky API
    /// </summary>
    /// <remarks>
    /// See https://darksky.net/dev/docs
    /// </remarks>
    public class ForecastReader : HttpReader, IForecastReader
    {
        // API secret key
        private string _key;
        private const string BaseUrl = "https://api.darksky.net/forecast/";

        public ForecastReader(string key)
        {
            _key = key;
            Init();
        }
        public async Task<WeatherData> ReadDataAsync(Location location)
        {
            WeatherData data = null;
            // https://api.darksky.net/forecast/[key]/[latitude],[longitude]
            // ex: https://api.darksky.net/forecast/975b80d37eef043a5b2bf324dcc673ba/37.8267,-122.4233
            var response =  await GetAsync(location);
            if (response.IsSuccessStatusCode)
            {
                #if DEBUG
                string json = await response.Content.ReadAsStringAsync();
                #endif
                data = await response.Content.ReadAsAsync<WeatherData>();
            }

            return data;
        }

        public override Uri GetBaseAddress()
        {
            return new Uri(BaseUrl + _key + "/");
        }

        public override string GetRequestString(object arg)
        {
            var location = (Location)arg;
            var builder = new StringBuilder();
            builder.AppendFormat("{0},{1}", location.Latitude, location.Longitude);
            // exclude unused data, set units
            builder.Append("?exclude=minutely,hourly,daily,alerts,flags&units=si");
            builder.AppendFormat("&lang={0}", System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
            return builder.ToString();
        }
    }
}
