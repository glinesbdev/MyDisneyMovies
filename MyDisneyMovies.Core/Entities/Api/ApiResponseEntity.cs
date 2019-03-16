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
    /// Specifies the data that we want to get from the API.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiResponseEntity : IApiResponse
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("results")]
        public List<MovieEntity> Results { get; set; }
    }
}
