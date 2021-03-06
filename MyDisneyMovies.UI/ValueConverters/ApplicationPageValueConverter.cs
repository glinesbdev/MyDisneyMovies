﻿using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Enums;
using MyDisneyMovies.Core.IoC;
using MyDisneyMovies.UI.Pages;
using System;
using System.Diagnostics;
using System.Globalization;

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
                case ApplicationPage.AllMovies:
                    return new MoviesListPage();

                case ApplicationPage.PopularMovies:
                    return new PopularMoviesPage();

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
