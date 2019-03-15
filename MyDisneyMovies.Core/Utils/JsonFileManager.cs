using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyDisneyMovies.Core.Utils
{
    /// <summary>
    /// Manager class to handle json file operations
    /// </summary>
    public class JsonFileManager : IMovieFileManager
    {
        #region Private Members

        // Filename which we will save the data to
        private readonly string _fileName = @"movies";

        // File extension
        private readonly string _fileExtension = @".json";

        #endregion

        #region Private Methods

        // The full path where the data will be saved
        private string BuildFilePath() => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", $"{_fileName}{_fileExtension}");

        private string BuildFullPath(string path = null, string filename = null, string extension = null)
        {
            string fullFilename = (string.IsNullOrWhiteSpace(filename) && string.IsNullOrWhiteSpace(extension)) ? $"{filename}{extension}" : $"{_fileName}{_fileExtension}";

            return string.IsNullOrWhiteSpace(path) ? BuildFilePath() : Path.Combine(path, fullFilename);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Writes the json data to a file.
        /// </summary>
        /// <param name="movies">List of movie data.</param>
        /// <param name="path">Path to save the file on disk.</param>
        /// <param name="filename">Filename of the file to save.</param>
        /// <param name="extension">The extension of the file.</param>
        public void WriteMovies(IEnumerable<IMovie> movies, string path = null, string filename = null, string extension = null)
        {
            try
            {
                // Check if the requesting directory exists
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data"))
                {
                    // Create the directory if it doesn't exist
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Data");
                }

                // Creates or opens the file to write to
                using (StreamWriter file = File.CreateText(BuildFullPath(path, filename, extension)))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    // Serialize the movie data
                    serializer.Serialize(file, movies);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Reads the json data from a file and returns a list of <see cref="MovieEntity"/> data
        /// </summary>
        /// <param name="path">Path to read the file from on disk</param>
        /// <param name="filename">Filename to read</param>
        /// <returns></returns>
        public IEnumerable<IMovie> ReadMovies(string path = null, string filename = null, string extension = null)
        {
            try
            {
                // Open the file to write to
                using (StreamReader file = File.OpenText(BuildFullPath(path, filename, extension)))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    // Return the data read from the file
                    return (List<MovieEntity>)serializer.Deserialize(file, typeof(List<MovieEntity>));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Determines if the json file exists on disk already
        /// </summary>
        /// <param name="path">Path where the file is located</param>
        /// <param name="filename">Filename to check for</param>
        /// <returns></returns>
        public bool MovieFileExists(string path = null, string filename = null, string extension = null)
        {
            return File.Exists(BuildFullPath(path, filename, extension));
        }

        /// <summary>
        /// Deletes a file if the file exists
        /// </summary>
        /// <param name="path">Path where the file is located</param>
        /// <param name="filename">Filename to check for</param>
        public void DeleteFile(string path = null, string filename = null, string extension = null)
        {
            string fullPath = BuildFullPath(path, filename, extension);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        #endregion
    }
}
