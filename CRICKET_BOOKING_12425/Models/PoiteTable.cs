using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRICKET_BOOKING_12425.Models
{
    public class PoiteTable
    {
        [Key]
        public int PoiteTableId { get; set; }
        public int? BookingTeamsId { get; set; }
        public BookingTeams? BookingTeams { get; set; }
        public int? PlayMatch { get; set; }
        public int? WinMatch { get; set; }
        public int? LostMatch { get; set; }
        public double? Poite { get; set; }
        public int? TournamentId { get; set; }
        public Tournament? Tournament { get; set; }
        public int? AdminMasterId { get; set; }
        public AdminMaster? AdminMaster { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
