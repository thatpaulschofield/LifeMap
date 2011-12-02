namespace LifeMap.Membership.RegistrationProcess
{
    public class RegistrationLogin
    {
        public RegistrationLogin(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}