using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models.DTOs
{
    public class UserRegisterDTO: UserDTO
    {
        [Required(ErrorMessage = "Re type password cannot be empty")]
        [Compare("Password", ErrorMessage = "Password and retype password do not match")]
        public string ReTypePassword { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }
    }
}
