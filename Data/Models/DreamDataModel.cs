using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class DreamDataModel
    {
        [Required]
        public int Id { get; }
        [Required]
        public int UserId { get; }
        [Required]
        public string Title { get; }
        [Required]
        public string Story { get; }
        [Required]
        public DateTime CreationDateTime { get; }

        public DreamDataModel(int id, int userId, string title, string story, DateTime creationDateTime)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Story = story;
            CreationDateTime = creationDateTime;
        }
    }
}
