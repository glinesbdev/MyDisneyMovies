using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Factories;
using MyDisneyMovies.Core.IoC;
using System.Linq;

namespace MyDisneyMovies.Core.Tests.IoCTests
{
    [TestClass]
    public class NinjectIoCTests
    {
        private static NinjectIoC ninjectIoC;

        [ClassInitialize]
        public static void InitClass(TestContext context)
        {
            ninjectIoC = IoCFactory<NinjectIoC>.Create();
            ninjectIoC.Setup();
        }

        [TestMethod]
        public void GetTest()
        {
            Assert.IsInstanceOfType(ninjectIoC.Get<ApplicationEntity>(), typeof(ApplicationEntity));
            Assert.IsTrue(ninjectIoC.Kernel.GetBindings(typeof(ApplicationEntity)).Count() == 1);
        }

        [TestMethod]
        public void RemoveTest()
        {
            ninjectIoC.Remove<ApplicationEntity>();
            Assert.IsTrue(ninjectIoC.Kernel.GetBindings(typeof(ApplicationEntity)).Count() == 0);
        }
    }
}
