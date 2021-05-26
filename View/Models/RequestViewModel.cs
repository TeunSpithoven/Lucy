using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace View.Models
{
    public class RequestViewModel
    {
        [Key]
        public int Id { get; set; }
        public int User1 { get; set; }
        public int User2 { get; set; }
        public bool Confirmed { get; set; }

        public RequestViewModel(int id, int user1, int user2, bool confirmed)
        {
            Id = id;
            User1 = user1;
            User2 = user2;
            Confirmed = confirmed;
        }

        public RequestViewModel()
        {
            
        }
    }
}
