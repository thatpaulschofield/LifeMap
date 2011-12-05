using System;
using CommonDomain.Core;
using LifeMap.Security.Events;

namespace LifeMap.Security
{
    public class Login : AggregateBase
    {
        private string _userName;
        private string _password;

        private Login()
        {
            base.Register<LoginCreatedEvent>(Apply);
        }

        public Login(Guid loginId, string userName, string password) : this()
        {
            base.RaiseEvent(new LoginCreatedEvent(loginId, userName, password));
        }

        public void Apply(LoginCreatedEvent @event)
        {
            base.Id = @event.LoginId;
            _userName = @event.UserName;
            _password = @event.Password;
        }
    }
}