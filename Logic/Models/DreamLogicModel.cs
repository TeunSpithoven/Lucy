using System;
using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    public class DreamLogicModel
    {
        [Range(0, double.PositiveInfinity)]
        public int Id { get; }
        [Range(0, double.PositiveInfinity)]
        public int UserId { get; }
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; }
        [Required]
        [StringLength(7500, MinimumLength = 20)]
        public string Story { get; }
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

        public DreamLogicModel(int userId, string title, string story)
        {
            UserId = userId;
            Title = title;
            Story = story;
        }

        public DreamLogicModel(int userId)
        {
            this.UserId = userId;
        }

        public DreamLogicModel()
        {
        }
    }
}
