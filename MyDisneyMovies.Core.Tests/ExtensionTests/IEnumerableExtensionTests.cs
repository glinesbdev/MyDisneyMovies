using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Extensions;
using MyDisneyMovies.Core.Tests.Helpers;
using MyDisneyMovies.Core.Utils;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace MyDisneyMovies.Core.Tests.ExtensionTests
{
    [TestClass]
    public class IEnumerableExtensionTests
    {
        private IEnumerable<MovieEntity> _movies;
        private JsonManager _jsonManager = new JsonManager();

        public IEnumerableExtensionTests()
        {
            _movies = _jsonManager.DeserializeJsonResponse(JsonManagerTestHelper.ValidJsonBlob).Results;
        }

        [TestMethod]
        public void FilterMovieTest()
        {
            IEnumerable<MovieEntity> filteredMovies = _movies.FilterMovies();

            Assert.IsTrue(filteredMovies.All(movie => movie.MediaType == "movie"));
        }
    }
}
