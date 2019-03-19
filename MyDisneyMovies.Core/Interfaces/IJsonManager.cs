using MyDisneyMovies.Core.Entities;

namespace MyDisneyMovies.Core.Interfaces
{
    /// <summary>
    /// Interface for a Json manager.
    /// </summary>
    public interface IJsonManager
    {
        /// <summary>
        /// Validate the Json data is valid Json.
        /// </summary>
        /// <param name="json">The json data</param>
        /// <returns></returns>
        bool ValidateJson(string json);

        /// <summary>
        /// Deserializes the JSON into usable data.
        /// </summary>
        /// <param name="response">Response from the web server.</param>
        /// <typeparam name="T">The type of movie.</typeparam>
        /// <returns></returns>
        BaseApiResponse<T> DeserializeJsonResponse<T>(string response) where T : IMovie;
    }
}
