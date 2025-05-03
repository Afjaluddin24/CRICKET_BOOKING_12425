using System.ComponentModel.DataAnnotations;

namespace CRICKET_BOOKING_12425.Models
{
    public class Adminteams
    {
        [Key]
        public int AdminteamsId { get; set; }
        public string Imgs { get; set; } = string.Empty;
        public string Name { get; set;} = string.Empty;
        public string Role {  get; set; } = string.Empty ;
        public string Description { get; set; } = string.Empty;

        public int? MaineAdminId { get; set; }
        public MaineAdmin? MaineAdmin { get; set; }
    }
}
