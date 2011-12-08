using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace LifeMap.Common.Infrastructure
{
    public interface IBootstrapper
    {
        IContainer BootstrapContainer();
        IContainer BootstrapContainer(IContainer container);
    }
}
