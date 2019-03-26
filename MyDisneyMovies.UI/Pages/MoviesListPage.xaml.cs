using MyDisneyMovies.Core.Entities;

namespace MyDisneyMovies.UI.Pages
{
    /// <summary>
    /// Interaction logic for MoviesListPage.xaml
    /// </summary>
    public partial class MoviesListPage : BasePage<MovieListEntity>
    {
        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MoviesListPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor that takes a view model
        /// </summary>
        /// <param name="viewModel"></param>
        public MoviesListPage(MovieListEntity viewModel) : base(viewModel)
        {
            viewModel.CurrentMovieList = viewModel.Movies;
            InitializeComponent();
        }

        #endregion
    }
}
