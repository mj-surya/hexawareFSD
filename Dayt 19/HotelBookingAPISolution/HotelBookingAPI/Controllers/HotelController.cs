using HotelBookingAPI.Exceptions;
using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpPost("AddHotel")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddHotel(HotelDTO hotelDTO)
        {
            var hotel = _hotelService.AddHotel(hotelDTO);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return BadRequest("Could not add hotel");
        }
        [HttpGet]
        public ActionResult GetHotel(string city)
        {
            string message = string.Empty;
            try
            {
                var result = _hotelService.GetHotels(city);
                return Ok(result);

            }
            catch (NoHotelsAvailableException ex)
            {
                message = ex.Message;
            }
            return BadRequest(message);
        }
        [HttpDelete("RemoveHotel")]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveHotel(int id)
        {
            var result = _hotelService.RemoveHotel(id);
            if (result)
            {
                return Ok("Hotel removed successfully");

            }
            return BadRequest("Could not remove hotel");

        }
        [HttpPost("UpdateHotel")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateHotel(int id, HotelDTO hotelDTO)
        {
            var result = _hotelService.UpdateHotel(id, hotelDTO);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest("Could not update");

        }
    }
}
