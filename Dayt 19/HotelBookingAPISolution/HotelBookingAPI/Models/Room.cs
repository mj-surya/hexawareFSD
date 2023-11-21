using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel hotel { get; set; }
        public string Picture { get; set; }
        public float Price { get; set; }
        public int Capacity { get; set; }
        public int TotalRooms { get; set; }
        public string Description { get; set; }
    }
}
