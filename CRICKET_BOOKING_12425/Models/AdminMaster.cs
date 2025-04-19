using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRICKET_BOOKING_12425.Models
{
    public class AdminMaster
    {
        public AdminMaster()
        {
            Bookings = new HashSet<BookingLimet>();
            Tournament = new HashSet<Tournament>();
            BookingsTeams = new HashSet<BookingTeams>();
            Poites = new HashSet<PoiteTable>();
            CricketMatches = new HashSet<Cricket_Matches>();
        }
        [Key]
        public int AdminMasterId { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string CubName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Map { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Location {  get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime EstabishDate {  get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; } = DateTime.Now;

        public ICollection<BookingLimet> Bookings { get; set; }
        public ICollection<Tournament> Tournament { get; set; }
        public ICollection<BookingTeams> BookingsTeams { get; set; }
        public ICollection<PoiteTable> Poites { get; set; }
        public ICollection<Cricket_Matches> CricketMatches { get; set; }

        [NotMapped]
        public class Authentication
        {
            public string Name { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}
