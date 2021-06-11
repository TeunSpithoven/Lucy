namespace Logic.Models
{
    public class CommentLogicModel
    {
        public int Id { get; set; }
        public UserLogicModel User { get; set; }
        public string Message { get; set; }

        public CommentLogicModel(int id, UserLogicModel user, string message)
        {
            Id = id;
            User = user;
            Message = message;
        }

        public CommentLogicModel()
        {
            
        }
    }
}
