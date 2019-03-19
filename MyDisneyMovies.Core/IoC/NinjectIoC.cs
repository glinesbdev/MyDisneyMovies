using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Enums;
using MyDisneyMovies.Core.Interfaces;
using MyDisneyMovies.Core.Utils;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace MyDisneyMovies.Core.IoC
{
    public sealed class NinjectIoC : IoCContainer
    {
        #region Public Members

        /// <summary>
        /// The kernel to control the IoC container.
        /// </summary>
        public IKernel Kernel { get; private set; } = new StandardKernel();

        #endregion

        #region Public Methods

        /// <summary>
        /// Get an object from the container.
        /// </summary>
        /// <typeparam name="T">The type of object to get.</typeparam>
        /// <returns></returns>
        public override T Get<T>()
        {
            T item = Kernel.TryGet<T>();

            if (item == null)
                return default(T);

            return item;
        }

        /// <summary>
        /// Remove an object from the container.
        /// </summary>
        /// <typeparam name="T">The type of object to remove.</typeparam>
        public override void Remove<T>()
        {
            Kernel.Unbind<T>();
        }

        /// <summary>
        /// Set up the container before use.
        /// NOTE: This must be called before the container can be accessed.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IMovie"/> object to get.</typeparam>
        public override void Setup<T>()
        {
            BindDefaultEntities();

            if (typeof(IMovie).IsAssignableFrom(typeof(T)))
                BindIMovieEntities<T>();
        }

        /// <summary>
        /// Set up the container before use without any <see cref="IMovie"/> objects.
        /// NOTE: This must be called before the container can be accessed.
        /// </summary>
        public void Setup()
        {
            BindDefaultEntities();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Bind the entties to the container.
        /// </summary>
        private void BindDefaultEntities()
        {
            Kernel.Bind<ApplicationEntity>().ToConstant(new ApplicationEntity());
        }

        /// <summary>
        /// Bind <see cref="IMovie"/> entities to the container.
        /// </summary>
        /// <typeparam name="T">The <see cref="IMovie"/> type.</typeparam>
        private void BindIMovieEntities<T>() where T : IMovie
        {
            ApiManager api = new ApiManager();

            // Get all movies from the API and cast them to the correct movie type.
            List<BaseMovie> baseMovieList = api.GetMovies<T>().Cast<BaseMovie>().ToList();

            MovieListEntity movieList = new MovieListEntity
            {
                // Run base movie filter
                Movies = BaseMovieFilterManager.FilterAllMovies(baseMovieList),

                // Filter movies by popularity.
                PopularMovies = BaseMovieFilterManager.FilterPopular(baseMovieList)
            };

            // TODO: Find a better place for this code?
            // Get the current movie list
            switch (Get<ApplicationEntity>().CurrentPage)
            {
                case ApplicationPage.AllMovies:
                    movieList.CurrentMovieList = movieList.Movies;
                    break;

                case ApplicationPage.PopularMovies:
                    movieList.CurrentMovieList = movieList.PopularMovies;
                    break;

                default:
                    movieList.CurrentMovieList = movieList.PopularMovies;
                    break;
            }

            // Bind the list of movies to IoC container.
            Kernel.Bind<MovieListEntity>().ToConstant(movieList);
        }

        #endregion
    }
}
