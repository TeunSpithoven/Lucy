using System.ComponentModel.DataAnnotations;

namespace View.Models
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public int User1 { get; set; }
        public int User2 { get; set; }
        public bool Confirmed { get; set; }

        public RequestViewModel(int id, int user1, int user2, bool confirmed)
        {
            Id = id;
            User1 = user1;
            User2 = user2;
            Confirmed = confirmed;
        }
    }
}
