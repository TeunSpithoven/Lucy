using System;

namespace Logic.Models
{
    public class DreamLogicModel
    {
        public int Id { get; }
        public UserLogicModel User { get; }
        public string Title { get; }
        public string Story { get; }
        public DateTime CreationDateTime { get; }

        public DreamLogicModel(int id, UserLogicModel user, string title, string story, DateTime creationDateTime)
        {
            Id = id;
            User = user;
            Title = title;
            Story = story;
            CreationDateTime = creationDateTime;
        }
        public DreamLogicModel(int id, UserLogicModel user, string title, string story)
        {
            Id = id;
            User = user;
            Title = title;
            Story = story;
        }

        public DreamLogicModel(UserLogicModel user, string title, string story)
        {
            User = user;
            Title = title;
            Story = story;
        }

        public DreamLogicModel(int userId)
        {
            this.User = new UserLogicModel(userId);
        }
    }
}
