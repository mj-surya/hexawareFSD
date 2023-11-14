using FirstAPI.Interfaces;
using FirstAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Registers user in the application
        /// </summary>
        /// <param name="userDTO">Contains registeration details</param>
        /// <returns>Returns user details or error message</returns>
        [HttpPost("register")]
        public ActionResult Register(UserRegisterDTO userDTO)
        {
            string message = "";
            try
            {
                var user = _userService.Register(userDTO);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            catch (DbUpdateException exp)
            {
                message = "Duplicate username";
            }
            catch (Exception)
            {

            }
            return BadRequest(message);
        }
        /// <summary>
        /// Logs in an user
        /// </summary>
        /// <param name="userDTO">Contains login credentials</param>
        /// <returns>Returns login details or error messages</returns>
        [HttpPost("Login")]
        public ActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized("Invalid username or password");
        }
    }
}
