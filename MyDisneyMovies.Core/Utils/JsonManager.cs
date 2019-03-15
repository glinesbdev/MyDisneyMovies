using MyDisneyMovies.Core.Interfaces;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace MyDisneyMovies.Core.Utils
{
    /// <summary>
    /// Manager for handling json interactions
    /// </summary>
    public class JsonManager : IJsonManager
    {
        #region Public Methods

        /// <summary>
        /// Validates that the json is valid
        /// </summary>
        /// <param name="json">Json to validate</param>
        /// <returns></returns>
        public bool ValidateJson(string json)
        {
            JSchema schema = JSchema.Parse(json);
            return JObject.Parse(json).IsValid(schema);
        }

        #endregion
    }
}
