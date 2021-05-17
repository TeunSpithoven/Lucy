namespace Data.Models
{
    public class UserDataModel
    {
        public int Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool LoggedIn { get; set; }

        public UserDataModel(int id, string username, string password, bool loggedIn)
        {
            Id = id;
            Username = username;
            Password = password;
            LoggedIn = loggedIn;
        }
    }
}
