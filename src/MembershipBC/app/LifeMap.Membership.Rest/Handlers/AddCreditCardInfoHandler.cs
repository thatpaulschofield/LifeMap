using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Rest.Resources;
using LifeMap.Membership.ViewModels;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Handlers
{
    public class AddCreditCardInfoHandler
    {
        public object Get(Guid id)
        {
            var registration = Repository.Instance.OpenSession().Query<RegistrationViewModel>().SingleOrDefault(x => x.Id == id);

            return Mapper.Map<RegistrationViewModel, AddCreditCardInfo>(registration);
        }

        public object Post(Guid id, string nameOnCard, string cardNumber, string cvvNumber, DateTime expirationDate)
        {
            var command = new EnterCreditCardInformationForRegistrationCommand
                              {
                                  RegistrationId = id,
                                  CardNumber = cardNumber,
                                  CvvNumber = cvvNumber,
                                  ExpirationDate = expirationDate,
                                  NameOnCard = nameOnCard
                              };
            Global.Bus.Send(command);
            return new OperationResult.SeeOther { RedirectLocation = Registration.Create(id).CreateUri() };
        }
    }
}