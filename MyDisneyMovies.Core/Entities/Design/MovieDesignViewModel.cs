namespace MyDisneyMovies.Core.Entities
{
    /// <summary>
    /// Data class for displaying movie data
    /// </summary>
    public class MovieDesignViewModel : MovieEntity
    {
        #region Singleton

        private static MovieDesignViewModel _instance;

        public static MovieDesignViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MovieDesignViewModel();
                }

                return _instance;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MovieDesignViewModel()
        {
            Title = "Incredibles 2";
            Overview = "Elastigirl springs into action to save the day, while Mr. Incredible faces his greatest challenge yet – taking care of the problems of his three children.";
            Popularity = 46.507f;
            PosterPath = "https://image.tmdb.org/t/p/w500/9lFKBtaVIhP7E2Pk0IY1CwTKTMZ.jpg";
        }

        #endregion
    }
}
