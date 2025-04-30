using System.ComponentModel.DataAnnotations;

namespace CRICKET_BOOKING_12425.Models
{
    public class New
    {
        [Key]
        public int NewsId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Imgs { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public  string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public  string Type { get; set; } = string.Empty;
        public int? Sore { get; set; }
        public int? TournamentId {  get; set; }
        public Tournament? Tournament { get; set; }
        public int? AdminMasterId { get; set; }
        public AdminMaster? AdminMaster { get; set; }
    }
}
