using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Interfaces
{
    public interface IBookingService
    {
        public BookingDTO AddBookingDetails(BookingDTO bookingDTO);
        public Booking UpdateBookingStatus(int bookingId, string status);
        public List<Booking> GetUserBooking(string userId);

        public List<Booking> GetBooking(int hotelId);
    }
}
