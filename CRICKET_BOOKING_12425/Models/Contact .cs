using System.ComponentModel.DataAnnotations;

namespace CRICKET_BOOKING_12425.Models
{
    public class Contact
    {
        [Key]

        public int ContactId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int? MaineAdminId { get; set; }
        public MaineAdmin? MaineAdmin { get; set; }
    }       
}
