using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Interfaces;
using MyDisneyMovies.Core.Utils;
using Ninject;
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
                BindEntities<T>();
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
        private void BindEntities<T>() where T : IMovie
        {
            ApiManager api = new ApiManager();
            MovieListEntity movieList = new MovieListEntity { Movies = api.GetMovies<T>().Cast<IMovie>().ToList() };

            movieList.Movies = BaseMovieFilterManager.Filter(movieList.Movies.Cast<BaseMovie>().ToList());

            Kernel.Bind<MovieListEntity>().ToConstant(movieList);
        }

        #endregion
    }
}
