using System;
using System.Collections.Generic;
using LifeMap.Membership.Rest.Handlers;
using OpenRasta.Web;

namespace LifeMap.Membership.Rest.Resources
{
    public class Registration
    {
        public static Registration Create()
        {
            return new Registration
                       {
                       };
        }

        public static Registration Create(Guid id)
        {
            var reg = Create();
            reg.Id = id;
            return reg;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid OfferId { get; set; }

        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CvvNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        
        public bool CanAddCreditCardInfo { get; set; }
        public bool CanAddLogin { get; set; }
        public bool CanSubmit { get; set; }
        
        public IEnumerable<Link> Links
        {
            get
            {
                var links = new List<Link>();
                if (CanAddCreditCardInfo)
                    links.Add(new Link("Add credit card info", new AddCreditCardInfo(Id).CreateUri(), "ccInfo"));
                if (CanAddLogin)
                {
                    links.Add(new Link("Add login", new Login(Id).CreateUri(), "loginInfo"));
                    links.Add(new Link("Log in through Facebook", new Uri("http://localhost:62571/login/" + this.Id + "/?afterLogin=" + new Registration{Id = this.Id}.CreateUri()), "facebookLoginInfo"));
                }
                if (CanSubmit)
                    links.Add(new Link("Submit registration", new SubmitRegistration { Id = this.Id }.CreateUri(), "submit"));
                links.Add(new Link("Registrations", new RegistrationList().CreateUri(), "registrations"));
                return links.AsReadOnly();
            }
        }
    }

    public class Link
    {
        public Link()
        {
        }
        public Link(string description, Uri uri, string relation)
        {
            Description = description;
            Uri = uri;
            Relation = relation;
        }

        public string Description { get; set; }
        public Uri Uri { get; set; }
        public string Relation { get; set; }

    }
}