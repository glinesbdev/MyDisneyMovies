using MyDisneyMovies.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Entities
{
    /// <summary>
    /// Specifies the data for the <see cref="IMovie"/> type that we want to get from the API.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class MovieEntityApiResponse : IApiResponse
    {
        /// <summary>
        /// The page of the response.
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// The total results of items of the response.
        /// </summary>
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        /// <summary>
        /// The total number of pages of the response.
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// The results to be serialized / deserailized.
        /// </summary>
        [JsonProperty("results")]
        public IEnumerable<MovieEntity> Results { get; set; }
    }
}
