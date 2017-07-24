using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WeatherForecast.Utility;
using WeatherForecast.ViewModel;
using Application = System.Windows.Application;
using AppResources = WeatherForecast.Resources;

namespace WeatherForecast
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IHandle<ViewModel.UpdateTrayIconTextEvent>
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // apply current locale
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CurrentCulture;
            SetupNotifyIcon();
            _eventAggregator = new EventAggregator();
            _eventAggregator.Subscribe(this);
            var main = new MainWindow(_eventAggregator);
            MainWindow.StateChanged += MainWindowOnStateChanged;
            MainWindow.Show();
        }

        private void MainWindowOnStateChanged(object sender, EventArgs eventArgs)
        {
            if (MainWindow.WindowState == WindowState.Minimized)
            {
                MainWindow.ShowInTaskbar = false;
                if (!_baloonShowed)
                {
                    _notifyIcon.BalloonTipText = String.Format(AppResources.BaloonTextPattern, AppResources.AppTitle);
                    _notifyIcon.ShowBalloonTip(3);
                    _baloonShowed = true;
                }
            }
            else
                MainWindow.ShowInTaskbar = true;
        }

        private void SetupNotifyIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = AppResources.weather16;
            _notifyIcon.Text = AppResources.AppTitle;
            _notifyIcon.Visible = true;
            _notifyIcon.DoubleClick += NotifyIconOnDoubleClick;
        }

        private void NotifyIconOnDoubleClick(object sender, EventArgs eventArgs)
        {
            BringWidnowToTop(MainWindow);
        }

        public void Handle(UpdateTrayIconTextEvent e)
        {
            _notifyIcon.Text = e.Text;
        }

        private void BringWidnowToTop(Window window)
        {
            if (window.WindowState == WindowState.Minimized)
                window.WindowState = WindowState.Normal;
            window.Activate();
        }

        private IEventAggregator _eventAggregator;
        private NotifyIcon _notifyIcon;
        private bool _baloonShowed = false;
    }
}
