using MyDisneyMovies.Data.Entities;
using System.Collections.Generic;

namespace MyDisneyMovies.UI.ViewModels
{
    public class MyMoviesViewModel : BaseViewModel
    {
        public List<Movie> Movies { get; set; }
    }
}
