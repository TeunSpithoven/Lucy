namespace Logic.Models
{
    public class CommentLogicModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public int DreamId { get; set; }

        public CommentLogicModel(int id, int userId, string message, int dreamId)
        {
            Id = id;
            UserId = userId;
            Message = message;
            DreamId = dreamId;
        }

        public CommentLogicModel(int userId, string message, int dreamId)
        {
            UserId = userId;
            Message = message;
            DreamId = dreamId;
        }

        public CommentLogicModel()
        {

        }
    }
}
