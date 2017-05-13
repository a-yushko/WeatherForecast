using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Model;

namespace WeatherForecast
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Locations = new ObservableCollection<LocationViewModel>();
            AddDummyData();
        }
        public ObservableCollection<LocationViewModel> Locations { get; set; }

        private void AddDummyData()
        {
            var forecast = new WeatherData()
            {
                Icon = WeatherIcon.ClearDay,
                Temperature = 17,
                Pressure = 200,
                Summary = "Clear"
            };
            var location = new Location()
            {
                Latitude = "50.43",
                Longitude = "30.52",
                Timezone = "Europe/Kiev"
            };
            var item = new LocationViewModel(location, forecast);
            Locations.Add(item);
        }
    }
}
