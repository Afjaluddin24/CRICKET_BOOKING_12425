using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRICKET_BOOKING_12425.Models
{
    public class BookingTeams
    {
        public BookingTeams()
        {
            PoiteTable = new HashSet<PoiteTable>();
        }
        [Key]
        public int BookingTeamsId { get; set; }

        [ForeignKey(nameof(Tournament))]
        public int TournamentId { get; set; }
        public virtual Tournament? Tournament { get; set; }
        public string TeamsName { get; set; } = string.Empty;
        public string CricHeroesUrl { get; set; } = string.Empty;
        public string CaptainName { get; set; } = string.Empty;
        public string VCaptainName { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string VContactNo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public int? AdminMasterId { get; set; }
        public AdminMaster? AdminMaster { get; set; }

        public int? BookingLimetId { get; set; }
        public BookingLimet? BookingLimet { get; set; }

        public ICollection<PoiteTable> PoiteTable { get; set; }
    }
}
