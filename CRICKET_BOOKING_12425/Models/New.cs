using System.ComponentModel.DataAnnotations;

namespace CRICKET_BOOKING_12425.Models
{
    public class New
    {
        [Key]
        public int NewsId { get; set; }
        public string? Title { get; set; }
        public string? Imgs { get; set; }
        public string? Name { get; set; }
        public DateTime Publisheddate { get; set; } = DateTime.Now;
        public DateTime Date { get; set; } = DateTime.Now;
        public  string? Category { get; set; }
        public string? Description { get; set; }
        public  string? Type { get; set; }
        public string? Sore { get; set; }
        public int? TournamentId {  get; set; }
        public Tournament? Tournament { get; set; }
        public int? AdminMasterId { get; set; }
        public AdminMaster? AdminMaster { get; set; }
    }
}
