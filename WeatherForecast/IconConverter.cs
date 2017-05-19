using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace WeatherForecast
{
    public class IconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var iconString = value as String;
            if (iconString != null)
            {
                return GetImage(iconString);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private object GetImage(string value)
        {
            object image = null;
            switch (value)
            {
                case "clear-day":
                    image = Application.Current.Resources["SunDrawingImage"];
                    break;
                case "clear-night":
                    image = Application.Current.Resources["MoonDrawingImage"];
                    break;
                case "rain":
                    image = Application.Current.Resources["CloudRainDrawingImage"];
                    break;
                case "snow":
                    image = Application.Current.Resources["SnowflakeDrawingImage"];
                    break;
                case "sleet":
                    image = Application.Current.Resources["CloudSnowDrawingImage"];
                    break;
                case "wind":
                    image = Application.Current.Resources["WindDrawingImage"];
                    break;
                case "fog":
                    image = Application.Current.Resources["CloudFogDrawingImage"];
                    break;
                case "cloudy":
                    image = Application.Current.Resources["CloudDrawingImage"];
                    break;
                case "partly-cloudy-day":
                    image = Application.Current.Resources["CloudSunDrawingImage"];
                    break;
                case "partly-cloudy-night":
                    image = Application.Current.Resources["CloudMoonDrawingImage"];
                    break;
                default:
                    image = Application.Current.Resources["CloudDrawingImage"];
                    break;
            }
            return image;
        }
    }
}
