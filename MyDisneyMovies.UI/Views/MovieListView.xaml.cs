using MyDisneyMovies.Data.Config;
using MyDisneyMovies.Data.Entities;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;

namespace MyDisneyMovies.UI.Views
{
    /// <summary>
    /// Interaction logic for MovieListView.xaml
    /// </summary>
    public partial class MovieListView : UserControl, INotifyPropertyChanged
    {
        private string _posterUri;
        public string PosterUri
        {
            get { return _posterUri; }
            set
            {
                _posterUri = value;
                OnPropertyChanged("PosterUri");
            }
        }

        public MovieListView()
        {
            PosterUri = "http://lab.csschopper.com/placeholder/images/placeholder_image_logo.png";
            InitializeComponent();
            MovieDetailScrollViewer.Visibility = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void MovieDataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoadMovieDetails(sender);
        }

        private void MovieDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            LoadMovieDetails(sender);
        }

        private void MovieDataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            LoadMovieDetails(sender);
        }

        private void LoadMovieDetails(object sender)
        {
            DataGrid grid = sender as DataGrid;
            Movie movieRow = (Movie)grid.SelectedItem;

            MickeyMouseImage.Visibility = Visibility.Hidden;
            MovieDetailScrollViewer.Visibility = Visibility.Visible;

            if (!string.IsNullOrWhiteSpace(movieRow.PosterPath))
            {
                PosterUri = $"{Settings.MoviePosterUrl}{movieRow.PosterPath}";
            }
            else
            {
                PosterUri = "http://lab.csschopper.com/placeholder/images/placeholder_image_logo.png";
            }

            MovieDetailTitle.Text = movieRow.Title;
            MovieDetailOverview.Text = movieRow.Overview;

            if (float.TryParse(movieRow.Popularity.ToString(), out float popularity))
            {
                MovieDetailPopularity.Text = popularity.ToString();
            }
        }
    }
}
