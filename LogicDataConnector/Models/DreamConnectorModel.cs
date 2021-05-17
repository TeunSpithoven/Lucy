using System;
using Objects;

namespace LogicDataConnector.Models
{
    public class DreamConnectorModel : Dream
    {
        public new int Id { get; private set; }
        public new int UserId { get; private set; }
        public new string Title { get; private set; }
        public new string Story { get; private set; }
        public new DateTime CreationDateTime { get; private set; }

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
