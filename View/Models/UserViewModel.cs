using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace View.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public UserViewModel(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }
}
