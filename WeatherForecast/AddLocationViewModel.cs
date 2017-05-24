using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WeatherForecast.Model;

namespace WeatherForecast
{
    public class AddLocationViewModel
    {
        public AddLocationViewModel(ILocationReader locationReader)
        {
            _reader = locationReader;
            Cities = new ObservableCollection<Location>();
        }

        public ObservableCollection<Location> Cities { get; set; }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value; 
                ReadCities();
            }
        }

        private async void ReadCities()
        {
            var cities = await _reader.FindLocationAsync(_searchString);
            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }
        private string _searchString;
        private readonly ILocationReader _reader;
    }
}
