using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using LifeMap.Analysis.Commands;
using LifeMap.Analysis.Events;
using LifeMap.Common.Domain;
using LifeMap.Membership.Events;
using Stateless;

namespace LifeMap.Analysis
{
    public class SubjectCreationSaga : SagaBase<IMessage>
    {
        private SubjectState _subjectState = SubjectState.NotCreated;
        private StateMachine<SubjectState, Trigger> _stateMachine;

        public SubjectCreationSaga ()
        {
            _stateMachine = new StateMachine<SubjectState, Trigger>(() => _subjectState, s => _subjectState = s);
            _stateMachine.Configure(SubjectState.NotCreated).Permit(Trigger.MemberSubscribed, SubjectState.WaitingForCreation).OnEntry(CreateSubject);
            _stateMachine.Configure(SubjectState.WaitingForCreation).Permit(Trigger.SubjectCreated, SubjectState.Created);
            
            base.Register<MemberCreatedEvent>(Transition);
            base.Register<MemberSubscribedEvent>(Transition);
            base.Register<SubjectCreatedEvent>(Transition);
        }

        private void CreateSubject()
        {
            base.Dispatch(new CreateSubjectCommand(base.Id));
        }

        public void Transition(MemberCreatedEvent @event)
        {
            base.Id = @event.MemberId;
        }

        public void Transition(MemberSubscribedEvent @event)
        {
            _stateMachine.Fire(Trigger.MemberSubscribed);
        }

        public void Transition(SubjectCreatedEvent @event)
        {
            _stateMachine.Fire(Trigger.SubjectCreated);
        }

        enum SubjectState
        {
            NotCreated, WaitingForCreation, Created
        }

        enum Trigger
        {
            MemberSubscribed, SubjectCreated
        }
    }
}
