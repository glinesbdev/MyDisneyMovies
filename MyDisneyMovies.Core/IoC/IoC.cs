using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Interfaces;
using MyDisneyMovies.Core.Utils;
using Ninject;
using System.Collections.Generic;

namespace MyDisneyMovies.Core
{
    /// <summary>
    /// The IoC container to manage and inject objects on demand.
    /// </summary>
    public static class IoC
    {
        #region Public Members

        /// <summary>
        /// The kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        #endregion

        #region Public Methods

        /// <summary>
        /// Set up the container before use.
        /// NOTE: This must be called before the container can be accessed.
        /// </summary>
        public static void Setup()
        {
            // Bind the required entities
            BindEntities();
        }

        /// <summary>
        /// Get an object from the container.
        /// </summary>
        /// <typeparam name="T">The type of object to get.</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Bind the entties to the container.
        /// </summary>
        private static void BindEntities()
        {
            ApiManager api = new ApiManager();

            Kernel.Bind<ApplicationEntity>().ToConstant(new ApplicationEntity());
            Kernel.Bind<MovieListEntity>().ToConstant(new MovieListEntity { Movies = (List<MovieEntity>)api.GetMovies() });
        }

        #endregion
    }
}
