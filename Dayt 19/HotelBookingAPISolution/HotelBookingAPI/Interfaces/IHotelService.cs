using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetHotels(string city);
        HotelDTO AddHotel(HotelDTO hotelDTO);
        HotelDTO UpdateHotel(int id, HotelDTO hotelDTO);
        bool RemoveHotel(int id);
    }
}
