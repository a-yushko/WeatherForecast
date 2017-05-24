using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherForecast.Model;

namespace WeatherForecast
{
    /// <summary>
    /// Interaction logic for AllLocation.xaml
    /// </summary>
    public partial class AddLocationWindow : Window
    {
        public AddLocationWindow()
        {
            InitializeComponent();
            var reader = ServiceFactory.GeLocationReader();
            DataContext = new AddLocationViewModel(reader);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
