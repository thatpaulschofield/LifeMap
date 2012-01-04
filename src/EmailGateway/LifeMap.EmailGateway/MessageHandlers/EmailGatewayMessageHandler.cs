using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using LifeMap.EmailGateway.Commands;
using NServiceBus;

namespace LifeMap.EmailGateway.MessageHandlers
{
        public class EmailGatewayMessageHandler : IHandleMessages<SendEmailCommand>
        {
            public EmailGatewayMessageHandler()
            {
                
            }
            public void Handle(SendEmailCommand command)
            {
                MailMessage eMailMessage = new MailMessage(command.From, command.To);
                eMailMessage.Body = command.Body;

                using (SmtpClient client = new SmtpClient("localhost"))
                    client.Send(eMailMessage);
            }
        }
}
