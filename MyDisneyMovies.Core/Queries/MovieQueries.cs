using MyDisneyMovies.Core.Contexts;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MyDisneyMovies.Core.Queries
{
    public static class MovieQueries
    {
        /// <summary>
        /// Get all movies from the MovieContext
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<MovieEntity> AllMovies()
        {
            using (MovieContext ctx = new MovieContext())
            {
                return ctx.Movies.FilterMovies().ToList();
            }
        }

        /// <summary>
        /// Get popular movies from the MovieContext
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<MovieEntity> PopularMovies()
        {
            using (MovieContext ctx = new MovieContext())
            {
                return ctx.Movies.Where(movie => movie.Popularity > 10.0).FilterMovies().ToList();
            }
        }
    }
}
