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

        /// <summary>
        /// Filter out movies by title
        /// </summary>
        private List<string> _titleFilters = new List<string> { "Killed" };

        private JsonFileManager _fileManager = new JsonFileManager();

        #endregion

        #region Public Methods

        /// <summary>
        /// Async method to get movies from the API
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IMovie>> GetMoviesAsync<IMovie>()
        {
            if (!_fileManager.MovieFileExists())
            {
                return await Task.Run(() => HttpGetMovies<IMovie>());
            }

            return await Task.Run(() => _fileManager.ReadMovies<IMovie>());
        }

        /// <summary>
        /// Get movies from the API
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IMovie> GetMovies<IMovie>()
        {
            // If we don't already have the data...
            if (!_fileManager.MovieFileExists())
            {
                // Get the data
                return HttpGetMovies<IMovie>();
            }

            // Otherwise, return the data from the json file
            return _fileManager.ReadMovies<IMovie>();
        }

        /// <summary>
        /// Get the result from the API and returns a deserialized JSON response.
        /// </summary>
        /// <param name="httpClient">The http client to make the call to the API.</param>
        /// <param name="url">The API URL to connect to.</param>
        /// <param name="page">The page of data to get for paginated results.</param>
        /// <returns></returns>
        public IApiResponse GetPaginatedApiResponse(HttpClient client, string url, int page)
        {
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            return DeserializeJsonResponse(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Gets an enumerable of <see cref="IMovie"/> objects over HTTP.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IMovie> HttpGetMovies<IMovie>()
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
                    ApiResponseEntity responseResult = GetPaginatedApiResponse(client, url, page) as ApiResponseEntity;

                    List<BaseMovie> movies = new List<BaseMovie>();

                    while (page < responseResult.TotalPages)
                    {
                        // Get the result for the next page
                        responseResult = GetPaginatedApiResponse(client, BuildPaginatedUrl(page), page) as ApiResponseEntity;

                        // Filter the data to return a more specific result from the API
                        movies.AddRange(responseResult.Results
                            .Where(movie => movie.MediaType == "movie")
                            .Select(movie => { movie.PosterPath = $"{Settings.MoviePosterUrl}{movie.PosterPath}"; return movie; })
                        );

                        // Filter the movies by title
                        movies = FilterMovieTitles(movies);

                        // Go to next page
                        page++;

                        // Write the data to the json file
                        _fileManager.WriteMovies(movies);

                        // Clear the items out of memory
                        movies.Clear();
                    }

                    // Get movies from the movie file we wrote to
                    if (_fileManager.MovieFileExists(_fileManager.PathToWrittenFile))
                        return _fileManager.ReadMovies<IMovie>(_fileManager.PathToWrittenFile);

                    throw new Exception($"Cannot read requested file at: {_fileManager.PathToWrittenFile}");
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
        public ApiResponseEntity DeserializeJsonResponse(string response)
        {
            return JsonConvert.DeserializeObject<ApiResponseEntity>(response);
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
        /// Filter out the movie titles containing words we don't want.
        /// </summary>
        /// <param name="movies">List of movies to filter.</param>
        /// <returns></returns>
        private List<BaseMovie> FilterMovieTitles(List<BaseMovie> movies)
        {
            if (movies.Any())
            {
                _titleFilters.ForEach(keyword =>
                {
                    movies = movies.Where(movie => !movie.Title.Contains(keyword)).ToList();
                });
            }

            return movies;
        }

        #endregion
    }
}
