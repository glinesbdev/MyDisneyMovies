using MyDisneyMovies.Core.Config;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        // The Json file manager
        private readonly JsonManager _jsonManager = new JsonManager();

        #endregion

        #region Public Members

        public string PathToWrittenFile { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Build the full path to the data file.
        /// </summary>
        /// <param name="directoryPath">The path to the directory.</param>
        /// <param name="filename">The filename to query.</param>
        /// <param name="extension">The extension of the file.</param>
        /// <returns></returns>
        public string BuildFullPath(string directoryPath = null, string filename = null, string extension = null)
        {
            string fullFilename = (string.IsNullOrWhiteSpace(filename) && string.IsNullOrWhiteSpace(extension)) ? $"{filename}{extension}" : $"{_fileName}{_fileExtension}";

            PathToWrittenFile = string.IsNullOrWhiteSpace(directoryPath) ? Settings.MovieDataPath : Path.Combine(directoryPath, fullFilename);

            return PathToWrittenFile;
        }

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
                    // Create the directory if it doesn't exist
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Data");

                IEnumerable<IMovie> existingMovies = ReadMovies(BuildFullPath(path, filename, extension)) ?? new List<IMovie>();

                List<IMovie> existingMoviesList = existingMovies.ToList();
                existingMoviesList.AddRange(movies);

                // Append the Json to the file
                File.WriteAllText(BuildFullPath(path, filename, extension), JsonConvert.SerializeObject(existingMoviesList));
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
                if (MovieFileExists(BuildFullPath(path, filename, extension)))
                {
                    using (StreamReader file = File.OpenText(BuildFullPath(path, filename, extension)))
                    {
                        JsonSerializer serializer = new JsonSerializer();

                        // Return the data read from the file
                        return (List<MovieEntity>)serializer.Deserialize(file, typeof(List<MovieEntity>));
                    }
                }

                return null;
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
