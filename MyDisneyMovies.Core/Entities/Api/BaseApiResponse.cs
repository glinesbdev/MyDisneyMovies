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
    /// Base class for a generic API response.
    /// Derived classes need to specify the <see cref="JsonPropertyAttribute"/>
    /// names coming from whichever API this class is consuming data from.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class BaseApiResponse<T> : IApiResponse
        where T : IMovie
    {
        /// <summary>
        /// The page of the response.
        /// </summary>
        public abstract int Page { get; set; }

        /// <summary>
        /// The total results of items of the response.
        /// </summary>
        public abstract int TotalResults { get; set; }

        /// <summary>
        /// The total number of pages of the response.
        /// </summary>
        public abstract int TotalPages { get; set; }

        /// <summary>
        /// The results to be serialized / deserailized.
        /// </summary>
        public abstract IEnumerable<T> Results { get; set; }
    }
}
