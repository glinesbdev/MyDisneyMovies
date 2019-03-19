using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Factories;
using MyDisneyMovies.Core.Interfaces;
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
    public class IoCContainerTests
    {
        [TestMethod]
        public void AssignContainerTest()
        {
            IIoCContainer container = IoC.IoC.Container = new NinjectIoC();
            Assert.IsInstanceOfType(container, typeof(NinjectIoC));

            container = IoC.IoC.Container = new DemoOnlyDoNotUseIoC();
            Assert.IsInstanceOfType(container, typeof(DemoOnlyDoNotUseIoC));
        }
    }
}
