using MyDisneyMovies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Contexts
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("name=MyDisneyMovies") { }
        public DbSet<MovieEntity> Movies { get; set; }
    }
}
