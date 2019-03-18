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

        #endregion

        #region Public Methods

        /// <summary>
        /// Async method to get movies from the API
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetMoviesAsync<T>() where T : IMovie
        {
            // If we don't already have the data...
            if (!_fileManager.MovieFileExists())
            {
                // Get the data
                return await Task.Run(() => HttpGetMovies<T>());
            }

            // Otherwise, return the data from the json file
            return await Task.Run(() => _fileManager.ReadMovies<T>());
        }

        /// <summary>
        /// Get movies from the API
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetMovies<T>() where T : IMovie
        {
            // If we don't already have the data...
            if (!_fileManager.MovieFileExists())
            {
                // Get the data
                return HttpGetMovies<T>();
            }

            // Otherwise, return the data from the json file
            return _fileManager.ReadMovies<T>();
        }

        /// <summary>
        /// Get the result from the API and returns a deserialized JSON response.
        /// </summary>
        /// <param name="httpClient">The http client to make the call to the API.</param>
        /// <param name="url">The API URL to connect to.</param>
        /// <param name="page">The page of data to get for paginated results.</param>
        /// <returns></returns>
        public IApiResponse GetPaginatedApiResponse<T>(HttpClient client, string url, int page) where T : IMovie
        {
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            return DeserializeJsonResponse<T>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Gets an enumerable of <see cref="IMovie"/> objects over HTTP.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> HttpGetMovies<T>() where T : IMovie
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
                    if (GetPaginatedApiResponse<T>(client, url, page) is BaseApiResponse<T> responseResult)
                    {
                        // Determine the type of movie coming through the generic method
                        DetermineMovieApiResponeType<T>(ref responseResult);

                        List<T> movies = new List<T>();

                        while (page < responseResult.TotalPages)
                        {
                            // Get the result for the next page
                            responseResult = GetPaginatedApiResponse<T>(client, BuildPaginatedUrl(page), page) as BaseApiResponse<T>;

                            // Add the movies of the type coming through the generic method
                            movies.AddRange(responseResult.Results.Cast<T>().ToList());

                            // Write the data to the json file
                            _fileManager.WriteMovies(movies);

                            // Clear the items out of memory
                            movies.Clear();

                            // Go to next page
                            page++;
                        }

                        // Get movies from the movie file we wrote to
                        if (_fileManager.MovieFileExists())
                            return _fileManager.ReadMovies<T>();

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

        public IApiResponse GetApiResponse(HttpClient client, string url)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Helper Methods

        /// <summary>
        /// Deserializes the JSON to usable data.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public MovieEntityApiResponse<T> DeserializeJsonResponse<T>(string response) where T : IMovie
        {
            return JsonConvert.DeserializeObject<MovieEntityApiResponse<T>>(response);
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Builds the string to call the API.
        /// </summary>
        /// <param name="page">The page of data for the call.</param>
        /// <returns></returns>
        private string BuildPaginatedUrl(int page)
        {
            return $"{Settings.MovieDbBaseUrl}?api_key={Settings.MovieDbApiKey}&language=en-US&query=disney&page={page}&include_adult=false&region=US";
        }

        /// <summary>
        /// Detemines the movie API response type.
        /// </summary>
        /// <typeparam name="T">The tyep of movie to be determined.</typeparam>
        /// <param name="response">The reponse from the API.</param>
        private void DetermineMovieApiResponeType<T>(ref BaseApiResponse<T> response) where T : IMovie
        {
            switch (typeof(T).Name)
            {
                case nameof(MovieEntity):
                    response = response as MovieEntityApiResponse<T>;
                    response.Results.Cast<MovieEntity>().ToList();
                    break;
                default:
                    throw new Exception("Cannot detemine movie type.");
            }
        }

        #endregion
    }
}
