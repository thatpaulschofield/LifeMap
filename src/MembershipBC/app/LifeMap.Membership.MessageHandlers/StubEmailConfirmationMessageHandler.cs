using LifeMap.Membership.Commands;
using LifeMap.Membership.Events;
using NServiceBus;

namespace LifeMap.Membership.MessageHandlers
{
    public class StubEmailConfirmationMessageHandler : IMessageHandler<EmailConfirmationProcessStartedEvent>
    {
        private readonly IBus _bus;
        public StubEmailConfirmationMessageHandler()
        {
        }

        public StubEmailConfirmationMessageHandler(IBus bus)
        {
            _bus = bus;
        }
        public void Handle(EmailConfirmationProcessStartedEvent message)
        {
            _bus.Send(ConfirmEmailAddressCommand.Create(message.RegistrationId, message.Id));
        }
    }
}