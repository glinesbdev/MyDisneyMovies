using System.Configuration;

namespace MyDisneyMovies.Core.Config
{
    public static class Settings
    {
        public static readonly string MovieDbApiKey = ConfigurationManager.AppSettings["MovieDbApiKey"];
        public static readonly string MovieDbBaseUrl = ConfigurationManager.AppSettings["MovieDbBaseUrl"];
        public static readonly string MoviePosterUrl = ConfigurationManager.AppSettings["MoviePosterUrl"];
    }
}
