using MyDisneyMovies.UI.DataModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.UI.ValueConverters
{
    /// <summary>
    /// Converts an <see cref="ApplicationPage"/> to a WPF view
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Sets the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.MoviesList:
                    return null;

                case ApplicationPage.MyMovies:
                    return null;

                default:
                    // Sets a breakpoint in development mode if something went wrong
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
