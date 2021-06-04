using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class DreamDataModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
        public DateTime CreationDateTime { get; set; }

        public DreamDataModel(int id, int userId, string title, string story, DateTime creationDateTime)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Story = story;
            CreationDateTime = creationDateTime;
        }

        public DreamDataModel()
        {

        }
    }
}
