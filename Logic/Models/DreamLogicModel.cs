using System;
using System.ComponentModel.DataAnnotations;
using Objects;

namespace Logic.Models
{
    public class DreamLogicModel : IDream
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

        public DreamLogicModel(int id, int userId, string title, string story, DateTime creationDateTime)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Story = story;
            CreationDateTime = creationDateTime;
        }
        public DreamLogicModel(int id, int userId, string title, string story)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Story = story;
        }
    }
}
