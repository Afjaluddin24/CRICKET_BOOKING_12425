using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRICKET_BOOKING_12425.Models
{
    public class MaineAdmin
    {
        public MaineAdmin()
        {
            HeaderImg = new HashSet<HeaderImg>();
            AdminNews = new HashSet<AdminNews>();
            AdminVideos = new HashSet<AdminVideo>();
            Adminteams = new HashSet<Adminteams>();
        }
        [Key]
        public int MaineAdminId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MapAdress { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public ICollection<HeaderImg> HeaderImg { get; set; }
        public ICollection <AdminNews> AdminNews { get; set; }
        public ICollection <AdminVideo> AdminVideos { get; set; }
        public ICollection <Adminteams> Adminteams { get; set; }
        public ICollection <Contact> Contacts { get; set; }

        [NotMapped]
        public class MainAdmin
        {
            public string Name { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}
