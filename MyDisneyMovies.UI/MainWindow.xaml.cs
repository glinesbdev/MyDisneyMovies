using MyDisneyMovies.Data.Utils;
using MyDisneyMovies.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyDisneyMovies.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MovieListViewModel MovieListViewModel;

        public MainWindow()
        {
            InitializeComponent();
            MovieListViewModel = new MovieListViewModel
            {
                Movies = ApiManager.GetMovies()
            };

            MovieListViewModel.Movies
                .ForEach(movie => movie.Title = movie.Title.Length > 100 ? 
                         movie.Title.Substring(0, 100).PadLeft(3, '.') : 
                         movie.Title
                );

            DataContext = MovieListViewModel;
        }

        private void LoadMovieListView(object sender, RoutedEventArgs e)
        {
            DataContext = MovieListViewModel;
        }

        private void LoadMyMoviesView(object sender, RoutedEventArgs e)
        {
            DataContext = new MyMoviesViewModel();
        }

        private void Quit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
