using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Interfaces
{
    /// <summary>
    /// Interface for an Api Manager responsible for interacting with <see cref="IMovie"/> data.
    /// </summary>
    public interface IMovieApiManager
    {
        /// <summary>
        /// Wrapper method that checks if the data is already availble.
        /// If the data is not yet availabile, it connects with <see cref="HttpGetMovies"/>
        ///     to fetch the enumerable of <see cref="IMovie"/> objects.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetMovies<T>() where T : IMovie;

        /// <summary>
        /// Wrapper method that checks if the data is already available.
        /// If the data is not yet availabile, it connects with <see cref="HttpGetMovies"/>
        ///     to fetch the enumerable of <see cref="IMovie"/> objects asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetMoviesAsync<T>() where T : IMovie;

        /// <summary>
        /// Gets a generic, paginated response from a GET API call.
        /// </summary>
        /// <param name="client">The HTTP client to make the call</param>
        /// <param name="url">The URL to connect to</param>
        /// <param name="page">The page number of the request</param>
        /// <returns></returns>
        IApiResponse GetPaginatedApiResponse<T>(HttpClient client, string url, int page) where T : IMovie;

        /// <summary>
        /// Sends an HTTP GET request to fetch a enumerable <see cref="IMovie"/> objects.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> HttpGetMovies<T>() where T : IMovie;
    }
}
