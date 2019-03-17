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
        #region Private Members

        private static Dictionary<Type, T> factoryEntries = new Dictionary<Type, T>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Create a factory of some type. If a factory of that type has already been created, return it.
        /// </summary>
        /// <returns></returns>
        public static T Create()
        {
            if (!factoryEntries.ContainsKey(typeof(T)))
            {
                factoryEntries.Add(typeof(T), new T());
                return factoryEntries.Last().Value;
            }
            else
            {
                return factoryEntries
                    .Where(factory => typeof(T) == factory.Value.GetType())
                    .First().Value;
            }
        }

        #endregion
    }
}
