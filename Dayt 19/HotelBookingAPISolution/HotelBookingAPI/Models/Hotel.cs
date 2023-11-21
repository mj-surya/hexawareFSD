using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
        public string HotelName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public float StartingPrice { get; set; } = 0;
    }
}
