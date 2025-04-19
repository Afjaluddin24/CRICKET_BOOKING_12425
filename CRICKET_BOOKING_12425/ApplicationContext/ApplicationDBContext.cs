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
    }
}
