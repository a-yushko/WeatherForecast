using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model
{
    /// <summary>
    /// Reads heater using Dark Sky API
    /// </summary>
    /// <remarks>
    /// See https://darksky.net/dev/docs
    /// </remarks>
    public class DarkSkyForecastReader : IForecastReader
    {
        // API secret key
        private string _key;
        private static HttpClient _httpClient = new HttpClient();
        private const string BaseUrl = "https://api.darksky.net/forecast/";

        public DarkSkyForecastReader(string key)
        {
            _key = key;
        }
        public async Task<WeatherData> ReadDataAsync(Location location)
        {
            WeatherData data = null;
            // https://api.darksky.net/forecast/[key]/[latitude],[longitude]
            // ex: https://api.darksky.net/forecast/975b80d37eef043a5b2bf324dcc673ba/37.8267,-122.4233
            _httpClient.BaseAddress = new Uri(BaseUrl + _key + "/");
            var request = GetRequestString(location);
            var response =  await _httpClient.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                #if DEBUG
                string json = await response.Content.ReadAsStringAsync();
                #endif
                data = await response.Content.ReadAsAsync<WeatherData>();
            }

            return data;
        }

        private string GetRequestString(Location location)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{0},{1}", location.Latitude, location.Longitude);
            // exclude unused data, set units
            builder.Append("?exclude=minutely,hourly,daily,alerts,flags&units=si");
            return builder.ToString();
        }
    }
}
