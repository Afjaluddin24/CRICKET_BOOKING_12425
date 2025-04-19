using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRICKET_BOOKING_12425.Models
{
    public class BookingLimet
    {
        public BookingLimet()
        {
            Teams = new HashSet<BookingTeams>();
        }
        [Key]
        public int BookingLimetId { get; set; }
        public int? BookingPerson { get; set; }

        public int? AdminMasterId { get; set; }
        public AdminMaster? AdminMaster { get; set; }

        public ICollection<BookingTeams> Teams { get; set; }    

    }
}
