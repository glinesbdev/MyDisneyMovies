using MyDisneyMovies.Core.Entities;
using System.Data.Entity;

namespace MyDisneyMovies.Core.Contexts
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("name=MyDisneyMovies") { }
        public DbSet<MovieEntity> Movies { get; set; }
    }
}
