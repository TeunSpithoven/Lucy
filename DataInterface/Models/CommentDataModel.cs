using System.ComponentModel.DataAnnotations;

namespace DataInterface.Models
{
    public class CommentDataModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public int DreamId { get; set; }

        public CommentDataModel(int id, int userId, string message, int dreamId)
        {
            Id = id;
            UserId = userId;
            Message = message;
            DreamId = dreamId;
        }

        public CommentDataModel(int id, int userId, string message)
        {
            Id = id;
            UserId = userId;
            Message = message;
        }

        public CommentDataModel(int userId, string message, int dreamId)
        {
            UserId = userId;
            Message = message;
            DreamId = dreamId;
        }

        public CommentDataModel()
        {
            
        }
    }
}
