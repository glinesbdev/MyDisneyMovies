using MyDisneyMovies.Core;
using MyDisneyMovies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.UI.ViewModels
{
    public class ViewModelLocator
    {
        #region Private Members

        private static ViewModelLocator _instance;

        #endregion

        #region Singleton

        /// <summary>
        /// Singleton of the view model locator
        /// </summary>
        public static ViewModelLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewModelLocator();
                }

                return _instance;
            }
        }

        #endregion

        #region Public Members

        public ApplicationEntity ApplicationEntity => IoC.Get<ApplicationEntity>();
        public MovieListEntity MovieListEntity => IoC.Get<MovieListEntity>();

        #endregion
    }
}
