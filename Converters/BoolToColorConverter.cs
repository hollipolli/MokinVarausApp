using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MokinVarausApp.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isReserved = (bool)value;
            return isReserved ? Colors.Red : Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
