using MyDisneyMovies.Core.Entities;
using System.ComponentModel;
using System.Windows.Controls;

namespace MyDisneyMovies.UI.Controls
{
    /// <summary>
    /// Interaction logic for MovieListControl.xaml
    /// </summary>
    public partial class MovieListControl : UserControl
    {
        public MovieListControl()
        {
            InitializeComponent();

            // Sort the items by popularity
            MovieList.Items.SortDescriptions.Clear();
            MovieList.Items.SortDescriptions.Add(new SortDescription("Popularity", ListSortDirection.Descending));
        }
    }
}
