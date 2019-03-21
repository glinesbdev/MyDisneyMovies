using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Tests.Helpers;
using MyDisneyMovies.Core.Utils;

namespace MyDisneyMovies.Core.Tests.UtilTests
{
    [TestClass]
    public class JsonManagerTests
    {
        private JsonManager _jsonManager = new JsonManager();

        [TestMethod]
        public void ValidateJsonTest()
        {
            Assert.IsTrue(_jsonManager.ValidateJson(JsonManagerTestHelper.ValidJsonBlob));
        }

        [TestMethod]
        [ExpectedException(typeof(Newtonsoft.Json.JsonReaderException))]
        public void InvalidJsonTest()
        {
            _jsonManager.ValidateJson(JsonManagerTestHelper.InvalidJsonBlob);
        }

        [TestMethod]
        public void DeserializeJsonResponseTest()
        {
            Assert.IsInstanceOfType(_jsonManager.DeserializeJsonResponse(JsonManagerTestHelper.ValidJsonBlob), typeof(MovieEntityApiResponse));
        }
    }
}
