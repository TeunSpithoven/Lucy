using System;
using System.ComponentModel.DataAnnotations;

namespace View.Models
{
    public class DreamViewModel
    {
        public int Id { get; }

        [Required(ErrorMessage = "userId is required")]
        public int UserId { get; }

        [Required(ErrorMessage = "title is required")]
        [StringLength(200, ErrorMessage = "the title must be between 3 and 200 characters in length", MinimumLength = 3)]
        public string Title { get; }

        [Required(ErrorMessage = "story is required")]
        [StringLength(7500, ErrorMessage = "the story must be between 20 and 7500 characters in length", MinimumLength = 20)]
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
