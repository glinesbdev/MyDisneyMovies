using MyDisneyMovies.Core.Utils;
using System;
using System.Globalization;

namespace MyDisneyMovies.UI.ValueConverters
{
    /// <summary>
    /// Value converter that takes a popularity raing and shows a star based rating system
    /// </summary>
    public class MoviePopularityValueConverter : BaseValueConverter<MoviePopularityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value.ToString();

            if (double.TryParse(val, out double result))
            {
                return MovieStarRating.ConvertRating(result);
            }

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
