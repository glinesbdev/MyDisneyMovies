using MyDisneyMovies.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Entities
{
    /// <summary>
    /// State of the application
    /// </summary>
    public class ApplicationEntity : BaseEntity
    {
        #region Public Members

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.MoviesList;

        /// <summary>
        /// The current view model of the page when the <see cref="CurrentPage"/> changes.
        /// </summary>
        public BaseEntity CurrentPageViewModel { get; set; }

        /// <summary>
        /// Goes to the a page in the application
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicitly to the new page</param>
        public void GoToPage(ApplicationPage page, BaseEntity viewModel = null)
        {
            // Set the view model
            CurrentPageViewModel = viewModel;

            // See if page has changed
            var different = CurrentPage != page;

            // Set the current page
            CurrentPage = page;

            // If the page hasn't changed, fire off notification
            // So pages still update if just the view model has changed
            if (!different)
            {
                OnPropertyChanged(nameof(CurrentPage));
            }

        }

        #endregion
    }
}
