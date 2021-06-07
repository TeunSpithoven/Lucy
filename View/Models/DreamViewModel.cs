using System;
using System.ComponentModel.DataAnnotations;

namespace View.Models
{
    public class DreamViewModel
    {
        public int Id { get; }
        public int UserId { get; }
        public string Title { get; }
        public string Story { get; }
        public DateTime CreationDateTime { get; }

        public DreamViewModel(int id, int userId, string title, string story, DateTime creationDateTime)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Story = story;
            CreationDateTime = creationDateTime;
        }
    }
}
