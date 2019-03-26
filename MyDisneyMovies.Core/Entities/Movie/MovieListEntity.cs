using MyDisneyMovies.Core.Interfaces;
using System.Collections.Generic;

namespace MyDisneyMovies.Core.Entities
{
    public class MovieListEntity : BaseEntity
    {
        #region Private Members

        private IMovie _selectedMovie;

        private IEnumerable<IMovie> _movies;

        private IEnumerable<IMovie> _popularMovies;

        private IEnumerable<IMovie> _currentMovies;

        #endregion

        #region Public Members

        /// <summary>
        /// Get the list of current movies.
        /// </summary>
        public IEnumerable<IMovie> CurrentMovieList
        {
            get => _currentMovies;
            set
            {
                _currentMovies = value;
                OnPropertyChanged(nameof(CurrentMovieList));
            }
        }

        /// <summary>
        /// List of movies.
        /// </summary>
        public IEnumerable<IMovie> Movies
        {
            get => _movies;
            set
            {
                _movies = value;
                OnPropertyChanged(nameof(Movies));
            }
        }

        /// <summary>
        /// List of popular movies.
        /// </summary>
        public IEnumerable<IMovie> PopularMovies
        {
            get => _popularMovies;
            set
            {
                _popularMovies = value;
                OnPropertyChanged(nameof(PopularMovies));
            }
        }

        /// <summary>
        /// Tracks if a movie has been selected or not.
        /// </summary>
        public bool HasSelectedMovie => SelectedMovie != null;

        /// <summary>
        /// The selected movie.
        /// </summary>
        public IMovie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;

                OnPropertyChanged(nameof(SelectedMovie));
                OnPropertyChanged(nameof(HasSelectedMovie));
            }
        }

        #endregion
    }
}
