using MyDisneyMovies.Core.Entities;
using System;
using System.Linq;

namespace MyDisneyMovies.UI.Pages
{
    /// <summary>
    /// Interaction logic for PopularMoviesPage.xaml
    /// </summary>
    public partial class PopularMoviesPage : BasePage<MovieListEntity>
    {
        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PopularMoviesPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor that takes a view model
        /// </summary>
        /// <param name="viewModel"></param>
        public PopularMoviesPage(MovieListEntity viewModel) : base(viewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}
