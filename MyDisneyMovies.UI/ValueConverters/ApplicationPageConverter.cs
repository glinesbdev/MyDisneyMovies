using MyDisneyMovies.UI.DataModels;
using MyDisneyMovies.UI.Pages;
using MyDisneyMovies.UI.ViewModels;
using System;
using System.Diagnostics;
using System.Globalization;

namespace MyDisneyMovies.UI.ValueConverters
{
    /// <summary>
    /// Converts an <see cref="ApplicationPage"/> to a WPF page
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public static class ApplicationPageConverter
    {
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            // Find the page
            switch (page)
            {
                case ApplicationPage.MoviesList:
                    return new MoviesPage(viewModel as MoviesPageViewModel);

                default:
                    // Alert by setting a breakpoint
                    Debugger.Break();
                    return null;
            }
        }
    }
}
