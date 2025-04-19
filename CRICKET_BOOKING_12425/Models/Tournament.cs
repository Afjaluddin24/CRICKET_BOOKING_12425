using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRICKET_BOOKING_12425.Models
{
    public class Tournament
    {
        public Tournament()
        {
            PoiteTable = new HashSet<PoiteTable>();
            CricketMatches = new HashSet<Cricket_Matches>();
        }
        [Key]
        public int TournamentId { get; set; }
        public string TournamentName { get; set; } = string.Empty; 
        public DateTime StarDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public string TournamentType { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;

        [ForeignKey(nameof(BookingLimet))]
        public int? BookingLimetId { get; set; }
        public virtual BookingLimet? BookingLimet { get; set; }
        public int? AdminMasterId { get; set; }
        public AdminMaster? AdminMaster { get; set; }
        public ICollection<PoiteTable> PoiteTable { get; set; }

        public ICollection<Cricket_Matches> CricketMatches { get; set; }

    }
}
