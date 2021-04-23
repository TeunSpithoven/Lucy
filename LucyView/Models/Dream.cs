using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lucy5.Models
{
    public class Dream
    {
        // Id is de hoofdidentificatie voor een stuk data door [key]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }

        public Dream(string title, string story)
        {
            Title = title;
            Story = story;
        }

        public Dream()
        {
            
        }
    }
}
