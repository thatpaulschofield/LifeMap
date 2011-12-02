namespace LifeMap.Membership.RegistrationProcess
{
    public class RegistrationUser
    {
        public RegistrationUser(string firstName, string lastName, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
    }
}