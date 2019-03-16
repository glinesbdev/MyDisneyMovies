using MyDisneyMovies.Core;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Utils;
using Ninject;

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
        public override void Setup()
        {
            BindEntities();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Bind the entties to the container.
        /// </summary>
        private void BindEntities()
        {
            ApiManager api = new ApiManager();

            Kernel.Bind<ApplicationEntity>().ToConstant(new ApplicationEntity());
            Kernel.Bind<MovieListEntity>().ToConstant(new MovieListEntity { Movies = api.GetMovies() });
        }

        #endregion
    }
}
