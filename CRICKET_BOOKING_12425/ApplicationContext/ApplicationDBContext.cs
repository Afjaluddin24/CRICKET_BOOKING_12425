using CRICKET_BOOKING_12425.Models;
using Microsoft.EntityFrameworkCore;

namespace CRICKET_BOOKING_12425.ApplicationContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {
            
        }
        public DbSet<AdminMaster> AdminMasters { get; set; }
        public DbSet<BookingLimet> BookingsLimets { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<BookingTeams> BookingsTeams { get; set; }
        public DbSet<PoiteTable> PoiteTables { get; set; }
        public DbSet<Cricket_Matches> CricketMatches { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<MaineAdmin> MaineAdmins { get; set; }
        public DbSet<HeaderImg> HeaderImgs { get; set; }
        public DbSet<AdminNews> AdminNews { get; set; } 
        public DbSet<AdminVideo> AdminVideos { get; set; }
        public DbSet<Adminteams> AdminTeams { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}
