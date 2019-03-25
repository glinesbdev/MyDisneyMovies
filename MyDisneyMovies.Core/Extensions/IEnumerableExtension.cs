using MyDisneyMovies.Core.Config;
using MyDisneyMovies.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyDisneyMovies.Core.Extensions
{
    public static class IEnumerableExtension
    {
        #region Private Members

        /// <summary>
        /// Filter out movies by title.
        /// Can't control what comes from a 3rd party API ¯\_(ツ)_/¯
        /// </summary>
        private static string[] _titleFilters = new string[] { "I Killed My Lesbian Wife, Hung Her on a Meat Hook, and Now I Have a Three-Picture Deal at Disney" };

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> of fileterd movies.
        /// </summary>
        /// <param name="movies">The movies to filter.</param>
        /// <returns></returns>
        public static IEnumerable<MovieEntity> FilterMovies(this IEnumerable<MovieEntity> movies)
        {
            return movies.Where(movie => !_titleFilters.Contains(movie.Title))
                .Select(movie =>
                {
                    movie.PosterPath = $"{Settings.MoviePosterUrl}{movie.PosterPath}";
                    movie.Title = movie.Title ?? "No Title Given";

                    return movie;
                })
                .OrderBy(movie => movie.Popularity)
                .ThenBy(movie => movie.Title);
        }

        #endregion
    }
}
