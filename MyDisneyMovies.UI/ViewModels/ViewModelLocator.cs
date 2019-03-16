using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.IoC;

namespace MyDisneyMovies.UI.ViewModels
{
    /// <summary>
    /// Locator to get different entities throughout the application.
    /// Has "semi-singleton" functionality but not a fully singleton class.
    /// Designed as a wrapper class for UI developers; making it easier to find entities
    ///     without going through the IoC class specifically as that class should only
    ///     be used for application start up purposes.
    /// </summary>
    public class ViewModelLocator
    {
        #region Singleton

        /// <summary>
        /// Singleton of the view model locator
        /// </summary>
        public static ViewModelLocator Instance => Singleton<ViewModelLocator>.Instance;

        #endregion

        #region Public Members

        public ApplicationEntity ApplicationEntity => IoC.Container.Get<ApplicationEntity>();
        public MovieListEntity MovieListEntity => IoC.Container.Get<MovieListEntity>();

        #endregion
    }
}
