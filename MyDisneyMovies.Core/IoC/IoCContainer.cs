using MyDisneyMovies.Core.Interfaces;

namespace MyDisneyMovies.Core
{
    /// <summary>
    /// The abstract IoC container class from which to create more specific IoC container implementations.
    /// </summary>
    public abstract class IoCContainer : IIoCContainer
    {
        #region Public Methods

        /// <summary>
        /// Get an object from the container.
        /// </summary>
        /// <typeparam name="T">The type of object to get.</typeparam>
        /// <returns></returns>
        public abstract T Get<T>();

        /// <summary>
        /// Remove an object from the container.
        /// </summary>
        /// <typeparam name="T">The type of object to remove.</typeparam>
        public abstract void Remove<T>();

        /// <summary>
        /// Set up the container before use.
        /// NOTE: This must be called before the container can be accessed.
        /// </summary>
        public abstract void Setup();

        #endregion
    }
}
