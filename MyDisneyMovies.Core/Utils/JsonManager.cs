using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;

namespace MyDisneyMovies.Core.Utils
{
    /// <summary>
    /// Manager for handling json interactions
    /// </summary>
    public class JsonManager : IJsonManager
    {
        #region Public Methods

        /// <summary>
        /// Validates that the given json is valid.
        /// </summary>
        /// <param name="json">Json to validate.</param>
        /// <returns></returns>
        public bool ValidateJson(string json)
        {
            JSchema schema = JSchema.Parse(json);
            return JObject.Parse(json).IsValid(schema);
        }

        /// <summary>
        /// Deserializes the JSON into usable data.
        /// </summary>
        /// <param name="response">Response from the web server.</param>
        /// <typeparam name="T">The type of movie.</typeparam>
        /// <returns></returns>
        public MovieEntityApiResponse DeserializeJsonResponse(string response)
        {
            if (ValidateJson(response))
                return JsonConvert.DeserializeObject<MovieEntityApiResponse>(response);

            throw new Exception("Invalid JSON");
        }

        #endregion
    }
}
