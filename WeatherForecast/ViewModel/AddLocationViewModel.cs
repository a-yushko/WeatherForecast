using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WeatherForecast.Model;
using WeatherForecast.Utility;

namespace WeatherForecast.ViewModel
{
    public class AddLocationViewModel
    {
        public AddLocationViewModel(ILocationReader locationReader, IEventAggregator eventAggregator)
        {
            _reader = locationReader;
            _eventAggregator = eventAggregator;
            Cities = new ObservableCollection<Location>();
        }

        public ObservableCollection<Location> Cities { get; set; }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (String.Compare(_searchString, value, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    _searchString = value;
                    ReadCities();
                }
            }
        }
        public Location SelectedLocation { get; set; }

        public void AddLocation()
        {
            if (SelectedLocation != null)
            {
                var location = new LocationViewModel(SelectedLocation);
                _eventAggregator.PublishEvent(new LocationAddedEvent() {Location = location});
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
        private readonly IEventAggregator _eventAggregator;
    }
}
