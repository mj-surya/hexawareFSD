using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
