using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeMap.Common.Domain;
using NServiceBus;

namespace LifeMap.Security.Commands
{
    [Serializable]
    public class VerifyEmailAddressCommand : MessageBase
    {
    }
}
