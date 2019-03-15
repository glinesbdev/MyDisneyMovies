﻿using MyDisneyMovies.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDisneyMovies.Core.Entities
{
    /// <summary>
    /// Entity to hold the movie data.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class MovieEntity : BaseEntity, IMovie
    {
        #region Public Members

        [JsonProperty("popularity")]
        public float Popularity { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("vote_count")]
        public int? VoteCount { get; set; }

        [JsonProperty("vote_average")]
        public float? VoteAverage { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

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

        #endregion
    }
}
