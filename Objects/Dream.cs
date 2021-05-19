using System;

namespace Objects
{
    public interface IDream
    {
        public int Id { get; }
        public int UserId { get; }
        public string Title { get; }
        public string Story { get; }
        public DateTime CreationDateTime { get; }
    }
}
