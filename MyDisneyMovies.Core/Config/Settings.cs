using System;
using System.Configuration;
using System.IO;

namespace MyDisneyMovies.Core.Config
{
    public static class Settings
    {
        public static readonly string MovieDbApiKey = ConfigurationManager.AppSettings["MovieDbApiKey"];
        public static readonly string MovieDbBaseUrl = ConfigurationManager.AppSettings["MovieDbBaseUrl"];
        public static readonly string MoviePosterUrl = ConfigurationManager.AppSettings["MoviePosterUrl"];
        public static readonly string MovieDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "movies.json");
    }
}
