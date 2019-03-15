using MyDisneyMovies.Data.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MyDisneyMovies.Data.Utils
{
    /// <summary>
    /// Manager for handling json interactions
    /// </summary>
    public static class JsonManager
    {
        /// <summary>
        /// Validates that the json is valid
        /// </summary>
        /// <param name="json">Json to validate</param>
        /// <returns></returns>
        public static bool ValidJson(string json)
        {
            JSchema schema = JSchema.Parse(json);
            return JObject.Parse(json).IsValid(schema);
        }
    }
}
