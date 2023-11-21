using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpPost("addBooking")]
        [Authorize(Roles = "User")]
        public ActionResult AddBooking(BookingDTO bookingDTO)
        {
            var booking = _bookingService.AddBookingDetails(bookingDTO);
            if (booking != null)
            {
                return Ok(booking);
            }
            return BadRequest("Could not book");
        }
        [HttpGet("adminBooking")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAdminBooking(int id)
        {
            var booking = _bookingService.GetBooking(id);
            if (booking != null)
            {
                return Ok(booking);
            }
            return BadRequest("No bookings found");
        }
        [HttpGet("userBooking")]
        [Authorize(Roles = "User")]
        public ActionResult GetUserBooking(string id)
        {
            var booking = _bookingService.GetUserBooking(id);
            if (booking != null)
            {
                return Ok(booking);
            }
            return BadRequest("No bookings found");
        }
        [HttpPost("Update")]
        public ActionResult UpdateBooking(int id, string status)
        {
            var booking = _bookingService.UpdateBookingStatus(id, status);
            if (booking != null)
            {
                return Ok(booking);
            }
            return BadRequest("couldn't update");
        }
    }
}
