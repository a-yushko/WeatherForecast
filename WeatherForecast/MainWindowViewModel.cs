using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Model;

namespace WeatherForecast
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IForecastReader _reader;
        private string _operation;

        public MainWindowViewModel()
        {
            Locations = new ObservableCollection<LocationViewModel>();
            AddDefaultData();
            InitReader();
            Refresh();
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

        private void InitReader()
        {
            var key = File.ReadAllText("key.txt");
            _reader = new DarkSkyForecastReader(key.Trim());
        }

        public async void Refresh()
        {
            Operation = "Loading...";
            try
            {
                var locations = Locations.Select(it => it.Location).ToList();
                Locations.Clear();
                foreach (var location in locations)
                {
                    var data = await _reader.ReadDataAsync(location);
                    Locations.Add(new LocationViewModel(data));
                }
                Operation = "Ready";
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
    }
}
