using MyDisneyMovies.Data.Utils;
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

namespace MyDisneyMovies.UI.Views
{
    /// <summary>
    /// Interaction logic for MyMoviesView.xaml
    /// </summary>
    public partial class MyMoviesView : UserControl
    {
        public MyMoviesViewModel ViewModel;

        public MyMoviesView()
        {
            InitializeComponent();
            ViewModel = new MyMoviesViewModel();
        }
    }
}
