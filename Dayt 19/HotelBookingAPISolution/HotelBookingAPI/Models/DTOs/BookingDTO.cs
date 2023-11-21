using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models.DTOs
{
    public class BookingDTO
    {
        [Required(ErrorMessage = "User ID cannot be empty")]
        public String UserId { get; set; }
        [Required(ErrorMessage = "Check_In Date cannot be empty")]
        public string CheckIn { get; set; }
        [Required(ErrorMessage = "check_out Date cannot be empty")]
        public string CheckOut { get; set; }
        [Required(ErrorMessage = "Room ID cannot be empty")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Total rooms cannot be empty")]
        public int TotalRoom { get; set; }
    }
}
