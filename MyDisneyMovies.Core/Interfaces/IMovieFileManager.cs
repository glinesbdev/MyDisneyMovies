using System.Collections.Generic;

namespace MyDisneyMovies.Core.Interfaces
{
    /// <summary>
    /// Interface for a file manager.
    /// </summary>
    public interface IMovieFileManager
    {
        /// <summary>
        /// Writes a file containing a enumerable of <see cref="IMovie"/> objects to the local file system.
        /// </summary>
        /// <param name="data">The information to be written to the file.</param>
        /// <param name="path">The fully qualified path to the file localtion.</param>
        /// <param name="filename">The filename of the file.</param>
        /// <param name="extension">The extension of the file.</param>
        void WriteMovies(IEnumerable<IMovie> movies, string path = null, string filename = null, string extension = null);

        /// <summary>
        /// Reads a file and returns a enumerable of <see cref="IMovie"/> objects.
        /// </summary>
        /// <param name="path">The fully qualified path to the file.</param>
        /// <param name="filename">The filename of the file.</param>
        /// <returns></returns>
        IEnumerable<IMovie> ReadMovies(string path = null, string filename = null, string extension = null);
    }
}
