using MyDisneyMovies.Core;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.IoC;
using System.Windows.Controls;

namespace MyDisneyMovies.UI.Pages
{
    /// <summary>
    /// Base page with view model functionality
    /// </summary>

    public class BasePage : Page
    {
        #region Private Members

        private object _viewModel;

        #endregion

        #region Public Members

        public object Model
        {
            get => _viewModel;
            set
            {
                // if the model hasn't changed, do nothing
                if (_viewModel == value)
                {
                    return;
                }

                _viewModel = value;

                // Run any view model updates
                OnViewModelChanged();

                // Update the data context of the page
                DataContext = _viewModel;
            }
        }

        #endregion

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected virtual void OnViewModelChanged()
        {

        }
    }

    public class BasePage<ViewModel> : BasePage
        where ViewModel : BaseEntity, new()
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            Model = IoC.Container.Get<ViewModel>();
        }

        /// <summary>
        /// Default constructor that takes a view model
        /// </summary>
        public BasePage(ViewModel viewModel)
        {
            Model = viewModel;
        }

        #endregion
    }
}
