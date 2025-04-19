using System.ComponentModel.DataAnnotations;

namespace CRICKET_BOOKING_12425.Models
{
    public class Cricket_Matches
    {
        [Key]
        public int CricketMatchesId { get; set; }
        public int? TournamentId { get; set; }  
        public Tournament? Tournament { get; set; }
        public int? BookingTeamsId { get; set; }
        public BookingTeams? BookingTeams { get; set; }
        public string? TeamA {  get; set; }
        public string? TeamB { get; set; }
        public DateTime MatchDate { get; set; } = DateTime.Now;
        public string Venue {  get; set; } = string.Empty;
        public string Match_type { get; set; } = string.Empty;
        public string  Match_status { get; set; } = string.Empty;
        public string ClubName {  get; set; } = string.Empty;
        public string Note {  get; set; } = string.Empty;   
        public int? AdminMasterId { get; set; } 
        public AdminMaster? AdminMaster { get; set; }
    }
}
