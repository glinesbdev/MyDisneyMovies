using MyDisneyMovies.Core.Factories;
using MyDisneyMovies.Core.Interfaces;

namespace MyDisneyMovies.Core.IoC
{
    public static class IoC
    {
        #region Private Members

        private static IIoCContainer _container = CreateNinjectContainer();

        #endregion

        #region Public Members

        /// <summary>
        /// Access to the currently set IoC container.
        /// </summary>
        public static IIoCContainer Container
        {
            get => _container;
            set
            {
                // If we're trying to give it a different type of container 
                // than the default container, set the new type.
                if (value.GetType() != _container.GetType())
                    _container = value;
            }
        }

        #endregion

        #region Public Methods;

        /// <summary>
        /// Create an IoC container based on the Ninject implementation.
        /// This is used as the default container.
        /// </summary>
        public static IIoCContainer CreateNinjectContainer()
        {
            return IoCFactory<NinjectIoC>.Create();
        }

        #endregion
    }
}
