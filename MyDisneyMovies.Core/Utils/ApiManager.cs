using MyDisneyMovies.Core.Config;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Utils
{
    /// <summary>
    /// Manager class to handle all API calls and results
    /// </summary>
    public class ApiManager : IMovieApiManager
    {
        #region Private Members

        private JsonFileManager _fileManager = new JsonFileManager();

        private JsonManager _jsonManager = new JsonManager();

        #endregion

        #region Public Methods

        /// <summary>
        /// Async method to get movies from the API
        /// </summary>
        /// <typeparam name="T">The type of movie.</typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<IMovie>> GetMoviesAsync()
        {
            // If we don't already have the data...
            if (!_fileManager.MovieFileExists())
                // Get the data
                return await Task.Run(() => HttpGetMovies());

            // Otherwise, return the data from the json file
            return await Task.Run(() => _fileManager.ReadMovies());
        }

        /// <summary>
        /// Get movies from the API
        /// </summary>
        /// <typeparam name="T">The type of movie.</typeparam>
        /// <returns></returns>
        public IEnumerable<IMovie> GetMovies()
        {
            // If we don't already have the data...
            if (!_fileManager.MovieFileExists())
                // Get the data
                return HttpGetMovies();

            // Otherwise, return the data from the json file
            return _fileManager.ReadMovies();
        }

        /// <summary>
        /// Get the result from the API and returns a deserialized JSON response.
        /// </summary>
        /// <param name="httpClient">The http client to make the call to the API.</param>
        /// <param name="url">The API URL to connect to.</param>
        /// <param name="page">The page of data to get for paginated results.</param>
        /// <typeparam name="T">The type of movie.</typeparam>
        /// <returns></returns>
        public IApiResponse GetPaginatedApiResponse(HttpClient client, string url, int page)
        {
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            return _jsonManager.DeserializeJsonResponse(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Gets an enumerable of <see cref="IMovie"/> objects over HTTP.
        /// </summary>
        /// <typeparam name="T">The type of movie.</typeparam>
        /// <returns></returns>
        public IEnumerable<IMovie> HttpGetMovies()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Starting page for paginated results
                    int page = 1;

                    // Initial API url
                    string url = BuildPaginatedUrl(page);

                    // The API result for the initial page
                    if (GetPaginatedApiResponse(client, url, page) is BaseApiResponse<MovieEntity> responseResult)
                    {
                        List<MovieEntity> movies = new List<MovieEntity>();

                        while (page < responseResult.TotalPages)
                        {
                            // Get the result for the next page
                            responseResult = GetPaginatedApiResponse(client, BuildPaginatedUrl(page), page) as BaseApiResponse<MovieEntity>;

                            // Add the movies to the list
                            movies.AddRange(responseResult.Results);

                            // Write the data to the json file
                            _fileManager.WriteMovies(movies);

                            // Clear the items out of memory
                            movies.Clear();

                            // Go to next page
                            page++;
                        }

                        // Get movies from the movie file we wrote to
                        if (_fileManager.MovieFileExists())
                            return _fileManager.ReadMovies();

                        throw new Exception("Cannot read requested file.");
                    }

                    throw new Exception("Could not get a proper API response from the server.");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Builds the string to call the API.
        /// </summary>
        /// <param name="page">The page of data for the call.</param>
        /// <typeparam name="T">The type of movie.</typeparam>
        /// <returns></returns>
        private string BuildPaginatedUrl(int page)
        {
            return $"{Settings.MovieDbBaseUrl}?api_key={Settings.MovieDbApiKey}&language=en-US&query=disney&page={page}&include_adult=false&region=US";
        }

        #endregion
    }
}
