using System;
using LifeMap.Common.Domain;

namespace LifeMap.Sales.Commands
{
    [Serializable]
    public class CreateCartCommand : MessageBase
    {
        public CreateCartCommand()
        {
            Id = Guid.NewGuid();
        }
        public CreateCartCommand(Guid cartId) : this()
        {
            CartId = cartId;
        }

        public Guid CartId { get; set; }
    }
}