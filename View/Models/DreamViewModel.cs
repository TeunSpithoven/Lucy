using System;
using System.ComponentModel.DataAnnotations;
using Objects;

namespace View.Models
{
    public class DreamViewModel : IDream
    {
        [Key]
        //[Required]
        public int Id { get; private set; }
        //[Required]
        public int UserId { get; private set; }
        //[Required]
        public string Title { get; private set; }
        //[Required]
        public string Story { get; private set; }
        //[Required]
        public DateTime CreationDateTime { get; private set; }

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
