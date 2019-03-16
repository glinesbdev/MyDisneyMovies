using MyDisneyMovies.Core.Interfaces;
using MyDisneyMovies.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Entities
{
    public class MovieListEntity : BaseEntity
    {
        #region Private Members

        private IMovie _selectedMovie;

        #endregion

        #region Public Members

        /// <summary>
        /// List of movies.
        /// </summary>
        public IEnumerable<IMovie> Movies { get; set; }

        /// <summary>
        /// Tracks if a movie has been selected or not.
        /// </summary>
        public bool HasSelectedMovie { get; set; }

        /// <summary>
        /// The selected movie.
        /// </summary>
        public IMovie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                HasSelectedMovie = true;

                OnPropertyChanged(nameof(SelectedMovie));
                OnPropertyChanged(nameof(HasSelectedMovie));
            }
        }

        #endregion
    }
}
