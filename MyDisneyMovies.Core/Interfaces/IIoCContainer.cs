using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.Interfaces
{
    /// <summary>
    /// Interface of an IoC container.
    /// </summary>
    public interface IIoCContainer
    {
        T Get<T>();
        void Remove<T>();
        void Setup<T>() where T : IMovie;
    }
}
