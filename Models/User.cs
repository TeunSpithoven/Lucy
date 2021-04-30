using System.ComponentModel.DataAnnotations;

namespace LucyFrontEnd.Models
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
