using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AntDesignToolbox.Converters
{
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return Visibility.Collapsed;
            if(value is bool b)
            {
                return b ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
