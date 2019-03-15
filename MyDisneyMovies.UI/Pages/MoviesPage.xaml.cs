using MyDisneyMovies.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyDisneyMovies.UI.Pages
{
    /// <summary>
    /// Interaction logic for MovieListPage.xaml
    /// </summary>
    public partial class MoviesPage : BasePage<MoviesPageViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MoviesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        public MoviesPage(MoviesPageViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}
}
