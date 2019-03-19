using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Factories;
using MyDisneyMovies.Core.IoC;
using MyDisneyMovies.Core.Tests.Helpers;
using MyDisneyMovies.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyDisneyMovies.Core.Tests.IoCTests
{
    [TestClass]
    public class IoCFactoryTests
    {
        [TestMethod]
        public void CreateTest()
        {
            NinjectIoC ninjectIoC = IoCFactory<NinjectIoC>.Create();
            NinjectIoC ninjectIoC2 = IoCFactory<NinjectIoC>.Create();

            Assert.IsInstanceOfType(ninjectIoC, typeof(NinjectIoC));
            Assert.AreEqual(ninjectIoC, ninjectIoC2);
        }
    }
}
