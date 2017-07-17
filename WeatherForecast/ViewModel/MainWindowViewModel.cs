using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
            LoadData();
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
        // TODO: refresh one item only
        public async void Refresh(LocationViewModel item = null)
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
                        Locations.Add(new LocationViewModel(location, data));
                }
                Operation = Resources.Ready;
            }
            catch (Exception e)
            {
                Operation = e.Message;
            }
        }

        public ObservableCollection<LocationViewModel> Locations { get; set; }

        public void OnClosed()
        {
            try
            {
                SaveData();
            }
            catch (Exception e)
            {
                Operation = e.Message;
            }
        }

        private void SaveData()
        {
            var storage = new LocationStorage();
            storage.SaveLocations(new AppSettings() { Locations = Locations.Select(it => it.Location).ToList()});
        }

        private void LoadData()
        {
            try
            {
                var storage = new LocationStorage();
                var settings = storage.ReadLocations();
                foreach (var location in settings.Locations)
                    Locations.Add(new LocationViewModel(location));
            }
            catch (Exception e)
            {
                Operation = e.Message;
            }
        }

        private void AddDefaultData()
        {
            Locations.Add(new LocationViewModel(new Location()
            {
                Latitude = "50.45466",
                Longitude = "30.5238",
                Name = "Kiev",
                Country = "Ukraine",
                Timezone = "Europe/Kiev"
            }));
            Locations.Add(new LocationViewModel(new Location()
            {
                Latitude = "40.730610",
                Longitude = "-73.935242",
                Name = "New York",
                Country = "USA",
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
            if (!Locations.Contains(e.Location))
                Locations.Add(e.Location);
            Refresh(e.Location);
        }
        #endregion
    }
}
