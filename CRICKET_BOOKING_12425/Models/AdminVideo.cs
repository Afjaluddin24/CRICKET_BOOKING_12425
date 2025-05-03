using System.ComponentModel.DataAnnotations;

namespace CRICKET_BOOKING_12425.Models
{
    public class AdminVideo
    {
        [Key]
        public int AdminVideoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Video {  get; set; } = string.Empty;
        public int? MaineAdminId { get; set; }
        public MaineAdmin? MaineAdmin { get; set; }
    }
}
