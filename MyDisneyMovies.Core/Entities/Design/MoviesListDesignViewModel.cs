using System.Collections.Generic;
using System.Linq;

namespace MyDisneyMovies.Core.Entities
{
    /// <summary>
    /// View model for use during design time for the movies list control.
    /// Has singleton capabilities but not soley a "singleton" class.
    /// </summary>
    public class MovieListDesignViewModel : MovieListEntity
    {
        #region Singleton

        public static MovieListDesignViewModel Instance => Singleton<MovieListDesignViewModel>.Instance;

        #endregion

        #region Public Members

        /// <summary>
        /// List of movies.
        /// </summary>
        //public List<MovieEntity> Movies { get; set; }

        /// <summary>
        /// The currently selected movie to display.
        /// </summary>
        //public MovieEntity SelectedMovie { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MovieListDesignViewModel()
        {
            // Populate movie list to display
            Movies = new List<MovieEntity>
            {
                new MovieEntity
                {
                    Title = "Incredibles 2",
                    Overview = "Elastigirl springs into action to save the day, while Mr. Incredible faces his greatest challenge yet – taking care of the problems of his three children.",
                    Popularity = 46.507f
                },
                new MovieEntity
                {
                    Title = "Mary Poppins",
                    Overview = "Singing, dancing and cleaning. What's not to love?",
                    Popularity = 12.82f
                }
            };

            SelectedMovie = Movies.First();
        }

        #endregion
    }
}
