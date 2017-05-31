using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using WeatherForecast.Model;
using WeatherForecast.Utility;

namespace WeatherForecast.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged, IHandle<LocationAddedEvent>
    {
        private readonly IForecastReader _reader;
        private readonly IEventAggregator _eventAggregator;
        private string _operation;

        public MainWindowViewModel(IForecastReader reader, IEventAggregator eventAggregator)
        {
            _reader = reader;
            _eventAggregator = eventAggregator;
            Locations = new ObservableCollection<LocationViewModel>();
            AddDefaultData();
            Refresh();
            _eventAggregator.Subscribe(this);
        }

        public string Operation
        {
            get { return _operation; }
            set
            {
                _operation = value;
                OnPropertyChanged(nameof(Operation));
            }
        }

        public async void Refresh()
        {
            Operation = Resources.Loading;
            try
            {
                var locations = Locations.Select(it => it.Location).ToList();
                Locations.Clear();
                foreach (var location in locations)
                {
                    var data = await _reader.ReadDataAsync(location);
                    if (data != null)
                        Locations.Add(new LocationViewModel(data));
                }
                Operation = Resources.Ready;
            }
            catch (JsonException e)
            {
                Operation = e.Message;
            }
            catch (InvalidOperationException e)
            {
                Operation = e.Message;
            }
        }

        public ObservableCollection<LocationViewModel> Locations { get; set; }

        private void AddDefaultData()
        {
            Locations.Add(new LocationViewModel(new Location()
            {
                Latitude = "50.43",
                Longitude = "30.52",
                Timezone = "Europe/Kiev"
            }));
            Locations.Add(new LocationViewModel(new Location()
            {
                Latitude = "40.730610",
                Longitude = "-73.935242",
                Timezone = "America/New_York"
            }));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Events
        public void Handle(LocationAddedEvent e)
        {
            Locations.Add(e.Location);
            Refresh();
        }
        #endregion
    }
}
