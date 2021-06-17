using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    public class RequestLogicModel
    {
        [Range(0, double.PositiveInfinity)]
        public int Id { get; set; }
        [Required]
        [Range(0, double.PositiveInfinity)]
        public int User1 { get; set; }
        [Required]
        [Range(0, double.PositiveInfinity)]
        public int User2 { get; set; }
        public bool Confirmed { get; set; }

        public RequestLogicModel(int id, int user1, int user2, bool confirmed)
        {
            Id = id;
            User1 = user1;
            User2 = user2;
            Confirmed = confirmed;
        }

        public RequestLogicModel(int user1, int user2, bool confirmed)
        {
            User1 = user1;
            User2 = user2;
            Confirmed = confirmed;
        }

        public RequestLogicModel()
        {
            
        }
    }
}
