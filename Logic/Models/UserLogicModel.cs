using System;

namespace Logic.Models
{
    public class UserLogicModel
    {
        public int Id { get; set; }
        public string Username { get; }
        public string Password { get; }
        public bool LoggedIn { get; set; }
        public DateTime CreationDateTime { get; set; }

        public UserLogicModel(int id, string username, string password, bool loggedIn, DateTime creationDateTime)
        {
            Id = id;
            Username = username;
            Password = password;
            LoggedIn = loggedIn;
            CreationDateTime = creationDateTime;
        }

        public UserLogicModel(int userId)
        {
            this.Id = userId;
        }
    }
}