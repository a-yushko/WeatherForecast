using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        private bool SearchEnabled = true;
        public AddLocationWindow(ILocationReader reader, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            DataContext = new AddLocationViewModel(reader, eventAggregator);
        }

        protected AddLocationViewModel ViewModel => DataContext as AddLocationViewModel;

        private void Add(object sender, RoutedEventArgs e)
        {
            ViewModel.AddLocation();
            this.Close();
        }

        private void TextBoxTextChanged(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (SearchEnabled)
                // TODO: add delay
                ViewModel.ReadCities(combo.Text);
            else
                SearchEnabled = true;
        }
        // TODO: fix bug with Menton
        private void SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SearchEnabled = false;
        }
    }
}
