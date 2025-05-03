using System.ComponentModel.DataAnnotations;

namespace CRICKET_BOOKING_12425.Models
{
    public class AdminNews
    {
        [Key]

        public int AdminNewsId { get; set; }
        public string Imag {  get; set; }   = string.Empty;
        public DateTime Date { get; set; }  = DateTime.Now;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? MaineAdminId { get; set; }
        public MaineAdmin? MaineAdmin { get; set; }
    }
}
