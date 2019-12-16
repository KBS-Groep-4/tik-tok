namespace RoeiJeRot.View.Wpf.Logic
{
    public class UserSession
    {
        public UserSession(int userId, string username, string email, string firstName, string lastName)
        {
            UserId = userId;
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public int UserId { get; set; }
        public string Username  { get; set; }
        public string  Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}