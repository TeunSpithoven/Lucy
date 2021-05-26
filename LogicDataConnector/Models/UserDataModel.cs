using System;
using System.ComponentModel.DataAnnotations;

namespace LogicDataConnector.Models
{
    public class UserDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool LoggedIn { get; set; }
        public DateTime CreationDateTime { get; set; }

        public UserDataModel(int id, string username, string password, bool loggedIn, DateTime creationDateTime)
        {
            Id = id;
            Username = username;
            Password = password;
            LoggedIn = loggedIn;
            CreationDateTime = creationDateTime;
        }
    }
}