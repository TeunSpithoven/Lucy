namespace Logic.Models
{
    public class CommentLogicModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }

        public CommentLogicModel(int id, int userId, string message)
        {
            Id = id;
            UserId = userId;
            Message = message;
        }

        public CommentLogicModel()
        {
            
        }
    }
}
