using System;
using System.ComponentModel.DataAnnotations;

namespace DataInterface.Models
{
    public class UserDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
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

        public UserDataModel()
        {
            
        }
    }
}