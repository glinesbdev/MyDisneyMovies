using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MyDisneyMovies.Data.Config;
using MyDisneyMovies.Data.Entities;
using Newtonsoft.Json;

namespace MyDisneyMovies.Data.Utils
{
    /// <summary>
    /// Manager class to handle all API calls and results
    /// </summary>
    public static class ApiManager
    {
        #region Private Members

        /// <summary>
        /// Filter out movies by title
        /// </summary>
        private static List<string> TitleFilter = new List<string> { "Killed" };

        #endregion

        #region Public Methods

        /// <summary>
        /// Async method to get movies from the API
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Movie>> GetMoviesAsync()
        {
            if (!FileManager.MovieFileExists())
            {
                return await Task.Run(() => GetMoviesViaHttp());
            }

            return await Task.Run(() => FileManager.ReadMoviesFromJson());
        }

        /// <summary>
        /// Get movies from the API
        /// </summary>
        /// <returns></returns>
        public static List<Movie> GetMovies()
        {
            // If we don't already have the data...
            if (!FileManager.MovieFileExists())
            {
                // Get the data
                return GetMoviesViaHttp();
            }

            // Otherwise, return the data from the json file
            return FileManager.ReadMoviesFromJson();
        }

        /// <summary>
        /// Calls the Http API to get the list of movies
        /// </summary>
        /// <returns></returns>
        private static List<Movie> GetMoviesViaHttp()
        {
            List<Movie> movies = new List<Movie>();

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Starting page for paginated results
                    int page = 1;

                    // The API result for the initial page
                    ApiResponseResult responseResult = GetApiResponseResult(httpClient, page);
                    
                    while (page < responseResult.TotalPages)
                    {
                        // Get the result for the next page
                        responseResult = GetApiResponseResult(httpClient, page);

                        // Filter the data to return a more specific result from the API
                        movies.AddRange(responseResult.Results
                            .Where(movie => movie.MediaType == "movie")
                            .OrderByDescending(movie => movie.Popularity)
                            .ThenBy(movie => movie.Title)
                            .Select(movie => { movie.PosterPath = $"{Settings.MoviePosterUrl}{movie.PosterPath}"; return movie; })
                        );

                        // Go to next page
                        page++;
                    }

                    // Filter out the movie titles containing words we don't want
                    TitleFilter.ForEach(keyword => {
                        movies = movies.Where(movie => !movie.Title.Contains(keyword)).ToList();
                    });

                    // Write the data to the json file
                    FileManager.WriteMoviesToJson(movies);

                    return movies;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        #endregion

        #region Public Helper Methods

        /// <summary>
        /// Deserializes the JSON to usable data
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static ApiResponseResult DeserializeJsonResponse(string response)
        {
            return JsonConvert.DeserializeObject<ApiResponseResult>(response);
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Get the result from the API
        /// </summary>
        /// <param name="httpClient">The http client to make the call to the API</param>
        /// <param name="page">The page of data to get for paginated results</param>
        /// <returns></returns>
        private static ApiResponseResult GetApiResponseResult(HttpClient httpClient, int page)
        {
            HttpResponseMessage response = httpClient.GetAsync($"{Settings.MovieDbBaseUrl}?api_key={Settings.MovieDbApiKey}&language=en-US&query=disney&page={page}&include_adult=false&region=US").Result;
            response.EnsureSuccessStatusCode();

            return DeserializeJsonResponse(response.Content.ReadAsStringAsync().Result);
        }

        #endregion

        #region Data Specific Structs

        /// <summary>
        /// Specifies the data that we want to get from the API since we don't need all of it
        /// </summary>
        public struct ApiResponseResult
        {
            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("total_results")]
            public int TotalResults { get; set; }

            [JsonProperty("total_pages")]
            public int TotalPages { get; set; }

            [JsonProperty("results")]
            public List<Movie> Results { get; set; }
        }

        #endregion
    }
}
