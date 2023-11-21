using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserRegisterDTO userRegisterDTO);
    }
}
