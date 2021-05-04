using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class UserLogicModel
    {
        public int Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool LoggedIn { get; set; }

        public UserLogicModel(int id, string username, string password, bool loggedIn)
        {
            Id = id;
            Username = username;
            Password = password;
            LoggedIn = loggedIn;
        }
    }
}
