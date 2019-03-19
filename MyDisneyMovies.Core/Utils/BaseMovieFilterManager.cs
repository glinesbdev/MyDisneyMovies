using MyDisneyMovies.Core.Config;
using MyDisneyMovies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Utils
{
    public static class BaseMovieFilterManager
    {
        #region Private Members

        /// <summary>
        /// Filter out movies by title
        /// </summary>
        private static List<string> _titleFilters = new List<string> { "Killed" };

        #endregion

        #region Private Methods

        /// <summary>
        /// Filter out the movie titles containing words we don't want.
        /// </summary>
        /// <param name="movies">List of movies to filter.</param>
        /// <returns></returns>
        public static IEnumerable<BaseMovie> FilterMovieTitles(IEnumerable<BaseMovie> movies, List<string> titles)
        {
            if (movies.Any())
            {
                titles.ForEach(keyword =>
                {
                    movies = movies.Where(movie => !movie.Title.Contains(keyword)).ToList();
                });
            }

            return movies;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Filter the enumerable of <see cref="BaseMovie"/> to specify the result set.
        /// </summary>
        /// <param name="movies">The enumerable of movies.</param>
        /// <returns></returns>
        public static IEnumerable<BaseMovie> FilterAllMovies(IEnumerable<BaseMovie> movies, List<string> titles = null)
        {
            movies = movies.Where(movie => movie.MediaType == "movie")
                .Select(movie => { movie.PosterPath = $"{Settings.MoviePosterUrl}{movie.PosterPath}"; return movie; });

            // Filter the movies by title
            movies = FilterMovieTitles(movies, titles ?? _titleFilters);

            return movies;
        }

        public static IEnumerable<BaseMovie> FilterPopular(IEnumerable<BaseMovie> movies)
        {
            return movies.Where(movie => movie.Popularity >= 10.0).ToList();
        }

        #endregion
    }
}
