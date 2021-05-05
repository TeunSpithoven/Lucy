using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Objects;

namespace View.Models
{
    public class DreamViewModel : Dream
    {
        public new int Id { get; private set; }
        public new int UserId { get; private set; }
        public new string Title { get; private set; }
        public new string Story { get; private set; }
        public new DateTime CreationDateTime { get; private set; }

        public DreamViewModel(int id, int userId, string title, string story, DateTime creationDateTime)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Story = story;
            CreationDateTime = creationDateTime;
        }
        // public DreamViewModel()
        // {
        //     
        // }
    }
}
