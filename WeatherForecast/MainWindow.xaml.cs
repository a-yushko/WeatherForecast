using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeatherForecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        protected MainWindowViewModel ViewModel
        {
            get { return DataContext as MainWindowViewModel; }
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Refresh();
        }

        private void AddLocation(object sender, RoutedEventArgs e)
        {
            var addForm = new AddLocationWindow { Owner = this };
            addForm.Show();
        }
    }
}
