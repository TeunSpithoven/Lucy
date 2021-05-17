using System;
using Objects;

namespace Data.Models
{
    public class DreamDataModel : Dream
    {
        public new int Id { get; private set; }
        public new int UserId { get; private set; }
        public new string Title { get; private set; }
        public new string Story { get; private set; }
        public new DateTime CreationDateTime { get; private set; }

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
