using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherForecast.Model;
using WeatherForecast.Utility;
using WeatherForecast.ViewModel;

namespace WeatherForecast
{
    /// <summary>
    /// Interaction logic for AllLocation.xaml
    /// </summary>
    public partial class AddLocationWindow : Window
    {
        public AddLocationWindow(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            var reader = ServiceFactory.GeLocationReader();
            DataContext = new AddLocationViewModel(reader, eventAggregator);
        }

        protected AddLocationViewModel ViewModel => DataContext as AddLocationViewModel;

        private void Add(object sender, RoutedEventArgs e)
        {
            ViewModel.AddLocation();
            this.Close();
        }
    }
}
