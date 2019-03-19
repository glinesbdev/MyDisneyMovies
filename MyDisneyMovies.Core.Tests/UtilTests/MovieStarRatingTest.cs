using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Tests.Helpers;
using MyDisneyMovies.Core.Utils;
using System.Linq;

namespace MyDisneyMovies.Core.Tests.UtilTests
{
    [TestClass]
    public class MovieStarRatingTest
    {
        [TestMethod]
        public void ConvertRatingTest()
        {
            string fiveStarRating = MovieStarRating.ConvertRating(50.0);
            Assert.AreEqual(fiveStarRating.Length, 5);

            string fourStarRating = MovieStarRating.ConvertRating(40.0);
            Assert.AreEqual(fourStarRating.Length, 4);

            string threeStarRating = MovieStarRating.ConvertRating(30);
            Assert.AreEqual(threeStarRating.Length, 3);

            string twoStarRating = MovieStarRating.ConvertRating(20.0);
            Assert.AreEqual(twoStarRating.Length, 2);

            string oneStarRating = MovieStarRating.ConvertRating(10);
            Assert.AreEqual(oneStarRating.Length, 1);

            string noRating = MovieStarRating.ConvertRating(0.99);
            Assert.AreEqual(noRating.Length, 1);
        }
    }
}
