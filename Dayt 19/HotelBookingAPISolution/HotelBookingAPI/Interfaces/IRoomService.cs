using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetRooms(int hotelid, string checkIn, string checkOut);
        RoomDTO AddRoom(RoomDTO room);
        RoomDTO UpdateRoom(int id, RoomDTO room);
        bool RemoveRoom(int id);
    }
}
