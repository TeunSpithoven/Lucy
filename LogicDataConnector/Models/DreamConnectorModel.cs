using System;
using System.ComponentModel.DataAnnotations;
using Objects;

namespace LogicDataConnector.Models
{
    public class DreamConnectorModel : IDream
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

        public DreamConnectorModel(int id, int userId, string title, string story, DateTime creationDateTime)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Story = story;
            CreationDateTime = creationDateTime;
        }
        public DreamConnectorModel(int id, int userId, string title, string story)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Story = story;
        }
    }
}
