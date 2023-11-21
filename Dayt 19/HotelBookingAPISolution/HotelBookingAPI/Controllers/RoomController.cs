using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpPost(" GetAvailableRooms")]
        public ActionResult GetAvailableRooms(int hotelId, string checkIn, string checkOut)
        {
            string errorMessage = "";
            try
            {
                var result = _roomService.GetRooms(hotelId, checkIn, checkOut);
                if (result != null)
                {
                    return Ok(result);

                }
            }
            catch (NoRoomsAvailableException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);

        }
        [HttpPost("CreateRooms")]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRooms(RoomDTO roomDTO)
        {
            var room = _roomService.AddRoom(roomDTO);
            if (room != null)
            {
                return Ok(room);

            }
            return BadRequest("Could not add rooms");

        }
        [HttpDelete("DeleteRooms")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRooms(int id)
        {
            bool roomId = _roomService.RemoveRoom(id);
            if (roomId)
            {
                return Ok("The room has been deleted successfully");

            }
            return BadRequest("Invalid roomId");
        }
        [HttpPost("PromoteRooms")]
        [Authorize(Roles = "Admin")]
        public ActionResult PromoteRooms(int id, RoomDTO roomDTO)
        {
            var room = _roomService.UpdateRoom(id, roomDTO);
            if (room != null)
            {
                return Ok("Room updated successfully");

            }
            return BadRequest("Unable to update");

        }
    }
}
