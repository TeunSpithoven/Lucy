using System;

namespace Logic.Models
{
    public class DreamLogicModel
    {
        public int Id { get; }
        public int UserId { get; }
        public string Title { get; }
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
    }
}
