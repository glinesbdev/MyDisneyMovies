using MyDisneyMovies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDisneyMovies.Core.Tests.Helpers
{
    public static class JsonFileManagerHelper
    {
        private static int _id = 0;

        public static List<MovieEntity> Movies = new List<MovieEntity>
        {
            new MovieEntity
            {
                Title = "Test Title",
                Id = _id,
                Overview = "This is a test movie"
            },
            new MovieEntity
            {
                Title = "Test Title 2",
                Id = _id++,
                Overview = "This is the second test movie"
            }
        };
    }
}
