using System;

namespace Objects
{
    public class Dream
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string Title { get; private set; }
        public string Story { get; private set; }
        public DateTime CreationDateTime { get; private set; }
    }
}
