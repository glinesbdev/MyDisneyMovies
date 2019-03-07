using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDisneyList.Data.Entities
{
    public class Movie
    {
        [JsonProperty("popularity")]
        public float Populatrity { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName{ get; set; }

        [JsonProperty("vote_count")]
        public int? VoteCount { get; set; }

        [JsonProperty("vote_average")]
        public int? VoteAverage { get; set; }

        [JsonProperty("poster_path")]
        public object PosterPath { get; set; }

        [JsonProperty("first_air_date")]
        public string FirstAirDate { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("backdrop_path")]
        public object BackdropPath { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("origin_country")]
        public List<string> OriginCountry { get; set; }
    }
}
