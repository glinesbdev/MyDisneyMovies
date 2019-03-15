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
    }
}
