using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.UI.DataModels
{
    /// <summary>
    /// All of the pages of the application
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// No page
        /// </summary>
        None = 0,

        /// <summary>
        /// Movies list page
        /// </summary>
        MoviesList = 1,

        /// <summary>
        /// My movies page
        /// </summary>
        MyMovies = 2
    }
}
