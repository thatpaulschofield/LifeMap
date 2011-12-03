using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using LifeMap.Analysis.Commands;
using NServiceBus;

namespace LifeMap.Analysis.MessageHandlers
{
    public class SubjectMessageHandler : IHandleMessages<CreateSubjectCommand>
    {
        private readonly IRepository _repository;

        public SubjectMessageHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateSubjectCommand command)
        {
            var subject = new Subject(command.Id, command.SubjectId);
            _repository.Save(subject, Guid.NewGuid());
        }
    }
}
