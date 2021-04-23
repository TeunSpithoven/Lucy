using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lucy5.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User()
        {
            
        }

    }
}
