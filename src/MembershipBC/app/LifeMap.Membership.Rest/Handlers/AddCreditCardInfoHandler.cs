using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LifeMap.Membership.Commands;
using LifeMap.Membership.Rest.Resources;
using LifeMap.Membership.ViewModels;

namespace LifeMap.Membership.Rest.Handlers
{
    public class AddCreditCardInfoHandler
    {
        public object Get(Guid id)
        {
            var registration = Repository.Instance.OpenSession().Query<RegistrationViewModel>().SingleOrDefault(x => x.Id == id);

            return Mapper.Map<RegistrationViewModel, AddCreditCardInfo>(registration);
        }

        public void Post(Guid id, string nameOnCard, string cardNumber, string cvvNumber, DateTime expirationDate)
        {
            var command = new EnterCreditCardInformationForRegistrationCommand
                              {
                                  Id = id,
                                  CardNumber = cardNumber,
                                  CvvNumber = cvvNumber,
                                  ExpirationDate = expirationDate,
                                  NameOnCard = nameOnCard
                              };
            Global.Bus.Publish(command);
        }
    }
}