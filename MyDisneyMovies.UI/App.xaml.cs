using MyDisneyMovies.Core;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Enums;
using System.Windows;

namespace MyDisneyMovies.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Override the start up of the application
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Original application start up
            base.OnStartup(e);

            // Set up all of our entities for use
            IoC.Setup();

            // Navigate to the starting page
            //IoC.Get<ApplicationEntity>().GoToPage(ApplicationPage.MoviesList, IoC.Get<MovieListEntity>());

            // Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
