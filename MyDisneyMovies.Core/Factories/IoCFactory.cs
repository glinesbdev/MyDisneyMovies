using MyDisneyMovies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Factories
{
    /// <summary>
    /// IoC factory creator that creates classes that derive from the <see cref="IIoCContainer"/> interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class IoCFactory<T> where T : IIoCContainer, new()
    {
        #region Public Methods

        /// <summary>
        /// Create a factory of some type. Could be extended if more factory types were to be introduced.
        /// </summary>
        /// <returns></returns>
        public static T Create()
        {
            return new T();
        }

        #endregion
    }
}
