using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
    /// <summary>
    /// Converts the Alpha value to a Opacity Double and vice-versa.
    /// </summary>
    public class AlphaToOpacity : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var cent = (double)value;
                var brush = cent / 255F;
                return brush;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameterString = parameter as double?;

            if (parameterString == null || value.Equals(false))
                return DependencyProperty.UnsetValue;

            return parameter;
        }
    }
}
