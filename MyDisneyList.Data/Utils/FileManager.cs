using MyDisneyMovies.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyDisneyMovies.Data.Utils
{
    /// <summary>
    /// Manager class to handle file operations
    /// </summary>
    public static class FileManager
    {
        #region Private Members

        // Filename which we will save the data to
        private readonly static string FileName = @"movies.json";

        // The full path where the data will be saved
        private readonly static string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", FileName);

        #endregion

        #region Public Methods

        /// <summary>
        /// Writes the json data to a file
        /// </summary>
        /// <param name="movies">List of movie data</param>
        /// <param name="path">Path to save the file on disk</param>
        /// <param name="filename">Filename of the file to save</param>
        public static void WriteMoviesToJson(List<Movie> movies, string path = null, string filename = null)
        {
            string fullPath = string.IsNullOrWhiteSpace(path) ? FilePath : Path.Combine(path, string.IsNullOrWhiteSpace(filename) ? FileName : filename);

            try
            {
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data"))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Data");
                }

                using (StreamWriter file = File.CreateText(fullPath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, movies);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Reads the json data from a file and returns a list of <see cref="Movie"/> data
        /// </summary>
        /// <param name="path">Path to read the file from on disk</param>
        /// <param name="filename">Filename to read</param>
        /// <returns></returns>
        public static List<Movie> ReadMoviesFromJson(string path = null, string filename = null)
        {
            string fullPath = string.IsNullOrWhiteSpace(path) ? FilePath : Path.Combine(path, string.IsNullOrWhiteSpace(filename) ? FileName : filename);

            try
            {
                using (StreamReader file = File.OpenText(fullPath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return (List<Movie>)serializer.Deserialize(file, typeof(List<Movie>));
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
        public static bool MovieFileExists(string path = null, string filename = null)
        {
            string fullPath = string.IsNullOrWhiteSpace(path) ? FilePath : Path.Combine(path, string.IsNullOrWhiteSpace(filename) ? FileName : filename);

            return File.Exists(fullPath);
        }

        /// <summary>
        /// Deletes a file if the file exists
        /// </summary>
        /// <param name="path">Path where the file is located</param>
        /// <param name="filename">Filename to check for</param>
        public static void DeleteFile(string path = null, string filename = null)
        {
            string fullPath = string.IsNullOrWhiteSpace(path) ? FilePath : Path.Combine(path, string.IsNullOrWhiteSpace(filename) ? FileName : filename);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        #endregion
    }
}
