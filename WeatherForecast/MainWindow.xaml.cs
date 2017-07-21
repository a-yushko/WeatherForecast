using System;
using System.Windows;
using WeatherForecast.Model;
using WeatherForecast.Utility;
using WeatherForecast.ViewModel;

namespace WeatherForecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ILocationReader _locationReader;

        public MainWindow(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _locationReader = ServiceFactory.GeLocationReader();
            InitializeComponent();
            DataContext = new MainWindowViewModel(GetReader(), _eventAggregator);
        }

        protected MainWindowViewModel ViewModel => DataContext as MainWindowViewModel;

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Refresh();
        }

        private void AddLocation(object sender, RoutedEventArgs e)
        {
            var addForm = new AddLocationWindow(_locationReader, _eventAggregator) { Owner = this };
            addForm.Show();
        }

        private IForecastReader GetReader()
        {
            try
            {
                return ServiceFactory.GetForecastReader();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(this, "Could not read key file");
                Close();
                return null;
            }
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ViewModel.OnClosed();
        }
    }
}
