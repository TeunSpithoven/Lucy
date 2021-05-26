using System.ComponentModel.DataAnnotations;

namespace LogicDataConnector.Models
{
    public class CommentDataModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }

        public CommentDataModel(int id, int userId, string message)
        {
            Id = id;
            UserId = userId;
            Message = message;
        }

        public CommentDataModel()
        {
            
        }
    }
}
