using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WeatherForecast.Model
{
    /// <summary>
    /// Contains various properties, each representing the average of a particular weather phenomenon 
    /// occurring during a period of time
    /// </summary>
    [DebuggerDisplay("{Temperature}, {Summary}")]
    public class DataPoint
    {
        public int Time { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public float PrecipIntensity { get; set; }
        public int PrecipProbability { get; set; }
        public float Temperature { get; set; }
        public float ApparentTemperature { get; set; }
        public float DewPoint { get; set; }
        public float Humidity { get; set; }
        public float WindSpeed { get; set; }
        public float WindBearing { get; set; }
        public float Visibility { get; set; }
        public float CloudCover { get; set; }
        public float Pressure { get; set; }
        public float Ozone { get; set; }
    }
}
