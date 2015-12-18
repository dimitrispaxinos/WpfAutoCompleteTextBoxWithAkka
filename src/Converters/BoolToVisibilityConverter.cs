using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfAutoCompleteTextBoxWithAkka.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = value as bool?;

            return boolValue != true ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
