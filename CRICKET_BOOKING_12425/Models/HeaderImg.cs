using System.ComponentModel.DataAnnotations;

namespace CRICKET_BOOKING_12425.Models
{
    public class HeaderImg
    {
       
        [Key]
        public int HeaderImgId { get; set; }
        public string Imgs { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? MaineAdminId { get; set; }
        public MaineAdmin? MaineAdmin { get; set; }

    }
}
