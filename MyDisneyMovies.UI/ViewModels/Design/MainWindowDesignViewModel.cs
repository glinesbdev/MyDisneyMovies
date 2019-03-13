using MyDisneyMovies.UI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyDisneyMovies.UI.ViewModels
{
    /// <summary>
    /// Design view model for the main window
    /// </summary>
    public class MainWindowDesignViewModel : MainWindowViewModel
    {
        #region Singleton

        private static MainWindowDesignViewModel _instance;

        public static MainWindowDesignViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainWindowDesignViewModel();
                }

                return _instance;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowDesignViewModel()
        {
            WindowCaption = "My Disney Movies";
        }

        #endregion
    }
}
