namespace RoeiJeRot.View.Wpf.Logic
{
    public class UserSession
    {
        private readonly string _username;
        private readonly string _email;
        private readonly string _firstName;
        private readonly string _lastName;

        public UserSession(string username, string email, string firstName, string lastName)
        {
            _username = username;
            _email = email;
            _firstName = firstName;
            _lastName = lastName;
        }

        public string Username  { get; set; }
        public string  Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}