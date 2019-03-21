using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Tests.Helpers;
using MyDisneyMovies.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyDisneyMovies.Core.Tests.UtilTests
{
    [TestClass]
    public class JsonFileManagerTests
    {
        private static JsonFileManager _jsonFileManager = new JsonFileManager();
        private static readonly string directory = AppDomain.CurrentDomain.BaseDirectory + "Data";
        private static readonly string file = "movieTest";
        private static readonly string extension = ".json";
        private static readonly string fullPath = Path.Combine(directory, $"{file}{extension}");

        [ClassInitialize()]
        public static void InitClass(TestContext context)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        [TestInitialize()]
        public void InitTests()
        {
            if (!_jsonFileManager.MovieFileExists(directory, file, extension))
                File.OpenWrite(fullPath);
        }

        [TestMethod]
        public void BuildFullPathTest()
        {
            string pathWithParams = _jsonFileManager.BuildFullPath(directory, file, extension);
            Assert.AreEqual(pathWithParams, Path.Combine(directory, $"{file}{extension}"));

            string pathWithoutParams = _jsonFileManager.BuildFullPath();
            Assert.AreEqual(pathWithoutParams, Path.Combine(directory, "movies.json"));
        }

        [TestMethod]
        public void ReadWriteMoviesTest()
        {
            _jsonFileManager.WriteMovies(JsonFileManagerHelper.Movies, directory, file, extension);
            Assert.IsTrue(_jsonFileManager.MovieFileExists(directory, file, extension));

            List<MovieEntity> movies = _jsonFileManager.ReadMovies(directory, file, extension).Cast<MovieEntity>().ToList();
            Assert.IsTrue(movies.Any());
        }

        [TestMethod]
        public void DeleteMoviesFileTest()
        {
            _jsonFileManager.DeleteFile(directory, file, extension);
            Assert.IsFalse(_jsonFileManager.MovieFileExists(directory, file, extension));
        }

        [ClassCleanup()]
        public static void CleanClass()
        {
            if (_jsonFileManager.MovieFileExists(directory, file, extension))
                _jsonFileManager.DeleteFile(directory, file, extension);

            Directory.Delete(directory);
        }
    }
}
