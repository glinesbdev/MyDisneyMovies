using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Entities
{
    /// <summary>
    /// Thread safe class used to give other classes "semi-singleton" functionality
    /// as the passed in type's constructor(s) still need to have a public access modifier.
    /// </summary>
    public sealed class Singleton<T>
        where T : class, new()
    {
        #region Private Members

        private static T _instance = null;

        private static readonly object _padlock = new object();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor which does not allow for any instances of itself.
        /// </summary>
        private Singleton() { }

        #endregion

        #region Public Methods

        public static T Instance
        {
            get
            {
                // Lock for thread safety
                lock (_padlock)
                {
                    if (_instance == null)
                        _instance = new T();

                    return _instance;
                }
            }
        }

        #endregion
    }
}
