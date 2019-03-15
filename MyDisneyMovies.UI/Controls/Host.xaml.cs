using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Enums;
using MyDisneyMovies.UI.Helpers;
using MyDisneyMovies.UI.Pages;
using System.Windows;
using System.Windows.Controls;

namespace MyDisneyMovies.UI.Controls
{
    /// <summary>
    /// Interaction logic for Host.xaml
    /// </summary>
    public partial class Host : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(Host), new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged));


        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public BaseEntity CurrentPageViewModel
        {
            get => (BaseEntity)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentPageViewModel"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel),
                typeof(BaseEntity), typeof(Host),
                new UIPropertyMetadata());

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Host()
        {
            InitializeComponent();
        }

        #endregion

        #region Property Changed Events

        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            // Get current values
            var currentPage = (ApplicationPage)value;
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            // Get the frames
            var newPageFrame = (d as Host).NewPage;
            var oldPageFrame = (d as Host).OldPage;

            // If the current page hasn't changed
            // just update the view model
            if (newPageFrame.Content is BasePage page &&
                page.ToApplicationPage() == currentPage)
            {
                // Just update the view model
                page.Model = currentPageViewModel;

                return value;
            }

            // Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            // Remove current page from new page frame
            newPageFrame.Content = null;

            // Move the previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            // Set the new page content
            newPageFrame.Content = currentPage.ToBasePage(currentPageViewModel);

            return value;
        }

        #endregion
    }
}
