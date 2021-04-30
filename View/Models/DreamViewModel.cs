using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace View.Models
{
    public class DreamViewModel
    {
        public int Id { get; set; }
        public int UserId { get; private set; }
        public string Title { get; private set; }
        public string Story { get; private set; }

        public DreamViewModel(int id, int userId, string title, string story)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Story = story;
        }
        public DreamViewModel()
        {
            
        }
    }
}
