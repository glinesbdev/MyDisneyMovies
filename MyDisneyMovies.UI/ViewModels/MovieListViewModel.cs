using MyDisneyMovies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.UI.ViewModels
{
    public class MoviesPageViewModel : BaseViewModel
    {
        public List<Movie> Movies { get; set; }
    }
}
