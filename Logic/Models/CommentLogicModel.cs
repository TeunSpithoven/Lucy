using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    public class CommentLogicModel
    {
        [Range(0, double.PositiveInfinity)]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(7500, MinimumLength = 20)]
        public string Message { get; set; }
        [Required]
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
