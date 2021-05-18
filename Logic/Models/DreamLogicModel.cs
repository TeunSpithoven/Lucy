using System;
using System.ComponentModel.DataAnnotations;
using Objects;

namespace Logic.Models
{
    public class DreamLogicModel : Dream
    {
        [Required]
        public new int Id { get; private set; }
        [Required]
        public new int UserId { get; private set; }
        [Required]
        public new string Title { get; private set; }
        [Required]
        public new string Story { get; private set; }
        [Required]
        public new DateTime CreationDateTime { get; private set; }

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
