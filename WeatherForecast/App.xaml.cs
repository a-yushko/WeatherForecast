using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WeatherForecast.Utility;

namespace WeatherForecast
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _eventAggregator = new EventAggregator();
            var main = new MainWindow(_eventAggregator);
            MainWindow.Show();
        }

        private IEventAggregator _eventAggregator;
    }
}
