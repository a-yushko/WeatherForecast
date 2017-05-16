using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Model;

namespace WeatherForecast
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IForecastReader _reader;
        private string _operation;

        public MainWindowViewModel()
        {
            Locations = new ObservableCollection<WeatherData>();
            Operation = "Ready";
            AddDummyData();
            InitReader();
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
                var data = await _reader.ReadDataAsync(GetDefaultLocation());
                Locations.Clear();
                Locations.Add(data);
                Operation = "Ready";
            }
            catch (InvalidOperationException e)
            {
                Operation = e.Message;
            }
        }

        public ObservableCollection<WeatherData> Locations { get; set; }

        private void AddDummyData()
        {
            var location = GetDefaultLocation();
            Locations.Add(new WeatherData() {Timezone = location.Timezone});
        }

        Location GetDefaultLocation()
        {
            return new Location()
            {
                Latitude = "50.43",
                Longitude = "30.52",
                Timezone = "Europe/Kiev"
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
