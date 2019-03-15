using MyDisneyMovies.Core;
using MyDisneyMovies.Core.Entities;
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
            MovieListEntity movieList = IoC.Get<MovieListEntity>();

            movieList.SelectedMovie = movie;
            movieList.HasSelectedMovie = true;
        }
    }
}
