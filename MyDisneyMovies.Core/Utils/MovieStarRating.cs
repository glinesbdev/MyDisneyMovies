using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Utils
{
    /// <summary>
    /// Provides methods regarding movie title ratings.
    /// </summary>
    public static class MovieStarRating
    {
        #region Public Static Methods

        /// <summary>
        /// Converts a <see cref="double"/> star rating into a <see cref="string"/> representation.
        /// This specifically uses FontAwesome font icons.
        /// </summary>
        /// <param name="rating">The popularity rating of the movie.</param>
        /// <returns></returns>
        public static string ConvertRating(double rating)
        {
            string starIcon = "\uf005";

            if (rating >= 50.0)
            {
                return string.Concat(Enumerable.Repeat(starIcon, 5));
            }
            else if (rating < 50.0 && rating >= 40.0)
            {
                return string.Concat(Enumerable.Repeat(starIcon, 4));
            }
            else if (rating < 40.0 && rating >= 30.0)
            {
                return string.Concat(Enumerable.Repeat(starIcon, 3));
            }
            else if (rating < 30.0 && rating >= 20.0)
            {
                return string.Concat(Enumerable.Repeat(starIcon, 2));
            }
            else if (rating < 20.0 && rating >= 10.0)
            {
                return string.Concat(Enumerable.Repeat(starIcon, 1));
            }
            else
            {
                // Doesn't have a rating. Return a '?' icon.
                return "\uf128";
            }
        }

        #endregion
    }
}
