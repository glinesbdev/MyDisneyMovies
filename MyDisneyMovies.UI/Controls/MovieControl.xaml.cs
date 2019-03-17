using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.IoC;
using MyDisneyMovies.UI.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyDisneyMovies.UI.Controls
{
    /// <summary>
    /// Interaction logic for MovieControl.xaml
    /// </summary>
    public partial class MovieControl : UserControl
    {
        public MovieControl()
        {
            InitializeComponent();
        }

        private void MovieContainer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            MovieEntity movie = border.DataContext as MovieEntity;
            MovieListEntity movieList = ViewModelLocator.Instance.MovieListEntity;

            if (movieList != null)
                movieList.SelectedMovie = movie;
        }
    }
}
