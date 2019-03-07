using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MyDisneyList.Data.Config;
using MyDisneyList.Data.Entities;
using Newtonsoft.Json;

namespace MyDisneyList.Data.Utils
{
    public static class ApiManager
    {
        public static List<Movie> GetMovies()
        {
            if (!FileManager.MovieFileExists())
            {
                return GetMoviesViaHttp();
            }

            return FileManager.ReadMoviesFromJson();
        }

        private static List<Movie> GetMoviesViaHttp()
        {
            List<Movie> movies = new List<Movie>();

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    int page = 1;
                    ApiResponseResult responseResult = GetApiResponseResult(httpClient, page);

                    while (page < responseResult.TotalPages)
                    {
                        responseResult = GetApiResponseResult(httpClient, page);
                        movies.AddRange(responseResult.Results.Where(movie => movie.MediaType != "person"));
                        page++;
                    }

                    FileManager.WriteMoviesToJson(movies);
                    return movies;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public static ApiResponseResult DeserializeJsonResponse(string response)
        {
            return JsonConvert.DeserializeObject<ApiResponseResult>(response);
        }

        private static ApiResponseResult GetApiResponseResult(HttpClient httpClient, int page)
        {
            HttpResponseMessage response = httpClient.GetAsync($"{Settings.MovieDbBaseUrl}?api_key={Settings.MovieDbApiKey}&language=en-US&query=disney&page={page}&include_adult=false&region=US").Result;
            response.EnsureSuccessStatusCode();

            return DeserializeJsonResponse(response.Content.ReadAsStringAsync().Result);
        }

        public struct ApiResponseResult
        {
            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("total_results")]
            public int TotalResults{ get; set; }

            [JsonProperty("total_pages")]
            public int TotalPages { get; set; }

            [JsonProperty("results")]
            public List<Movie> Results { get; set; }
        }
    }
}
