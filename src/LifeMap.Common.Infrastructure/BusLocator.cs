using System.Threading;
using NServiceBus;

namespace LifeMap.Common.Infrastructure
{
    public static class BusLocator
    {
        private static readonly AutoResetEvent _waitHandle = new AutoResetEvent(false);
        private static IBus _bus;
        public static IBus Bus
        {
            get
            {
                _waitHandle.WaitOne();
                return _bus;
            }
            set
            {
                _bus = value;
                _waitHandle.Set();
            }
        }
    }
}