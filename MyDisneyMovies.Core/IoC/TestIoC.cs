using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDisneyMovies.Core.IoC
{
    /// <summary>
    /// NOT A CLASS TO BE USED!!!
    /// Used to demonstrate that you can have multiple types of containers.
    /// See <see cref="IoC.Container"/> for more information.
    /// </summary>
    public sealed class DemoOnlyDoNotUseIoC : IoCContainer
    {
        public override T Get<T>()
        {
            throw new NotImplementedException();
        }

        public override void Remove<T>()
        {
            throw new NotImplementedException();
        }

        public override void Setup()
        {
            throw new NotImplementedException();
        }
    }
}
