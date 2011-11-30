using CommonDomain.Persistence;
using LifeMap.Analysis.Events;
using LifeMap.Membership.Events;
using NServiceBus;

namespace LifeMap.Analysis.MessageHandlers
{
    public class SubjectCreationSagaMessageHandler : IHandleMessages<MemberCreatedEvent>, IHandleMessages<MemberSubscribedEvent>, IHandleMessages<SubjectCreatedEvent>
    {
        private readonly ISagaRepository _repository;

        public SubjectCreationSagaMessageHandler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public void Handle(MemberCreatedEvent @event)
        {
            _repository.GetById<SubjectCreationSaga>(@event.MemberId).Transition(@event);
        }

        public void Handle(MemberSubscribedEvent @event)
        {
            _repository.GetById<SubjectCreationSaga>(@event.MemberId).Transition(@event);
        }

        public void Handle(SubjectCreatedEvent @event)
        {
            _repository.GetById<SubjectCreationSaga>(@event.Id).Transition(@event);
        }
    }
}