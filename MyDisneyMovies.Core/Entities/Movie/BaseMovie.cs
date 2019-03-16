using MyDisneyMovies.Core.Interfaces;

namespace MyDisneyMovies.Core.Entities
{
    /// <summary>
    /// Base abstract of any IMovie object.
    /// Specifies required fields that all movies need.
    /// </summary>
    public abstract class BaseMovie : BaseEntity, IMovie
    {
        /// <summary>
        /// Title of the movie.
        /// </summary>
        public abstract string Title { get; set; }

        /// <summary>
        /// Popularity rating of the movie.
        /// </summary>
        public abstract double Popularity { get; set; }

        /// <summary>
        /// Overview / description of the movie.
        /// </summary>
        public abstract string Overview { get; set; }

        /// <summary>
        /// Poster URI of the movie.
        /// </summary>
        public abstract string PosterPath { get; set; }
    }
}
