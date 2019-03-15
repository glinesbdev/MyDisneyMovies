using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyDisneyMovies.UI.ValueConverters
{
    /// <summary>
    /// Value converter to convert boolean to a visibility value
    /// </summary>
    public class BooleanToVisibilityValueConverter : BaseValueConverter<BooleanToVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }

            return (bool)value ? Visibility.Collapsed : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
