using System;
using System.ComponentModel.DataAnnotations;

namespace View.Models
{
    public class DreamViewModel
    {
        [Key]
        //[Required]
        public int Id { get; }
        //[Required]
        public int UserId { get; }
        //[Required]
        public string Title { get; }
        //[Required]
        public string Story { get; }
        //[Required]
        public DateTime CreationDateTime { get; }

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
