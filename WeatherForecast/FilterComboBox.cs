using System;
using System.Windows;
using System.Windows.Controls;

namespace WeatherForecast
{
    public class FilterComboBox : ComboBox
    {
        private SelectionChangedEventArgs _lastSelectionChangedArgs;

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            if (SelectedIndex != -1)
                _lastSelectionChangedArgs = e;
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            if (_lastSelectionChangedArgs != null)
                OnSelectionChanged(_lastSelectionChangedArgs);
            base.OnDropDownClosed(e);
        }
    }
}
