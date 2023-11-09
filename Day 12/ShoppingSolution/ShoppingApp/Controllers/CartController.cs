using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Interfaces;
using ShoppingApp.Models.DTOs;

namespace ShoppingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        /// <summary>
        /// Adding items to the cart of particular user by authorizing the role as user.
        /// </summary>
        /// <param name="cartDTO">Cart items that should be added to the respective user</param>
        /// <returns>This returns the added items or gives an error message</returns>
        [Authorize(Roles ="User")]
        [HttpPost("add")]
        public IActionResult AddToCart(CartDTO cartDTO)
        {
            var result = _cartService.AddToCart(cartDTO);
            if (result)
                return Ok(cartDTO);
            return BadRequest("Could not add item to cart");
        }
        /// <summary>
        /// Removing items from the cart of particular user by authorizing the role as user.
        /// </summary>
        /// <param name="cartDTO">Cart items that should be removed to the respective user</param>
        /// <returns>Returns either success message or error message</returns>
        [Authorize(Roles = "User")]
        [HttpPost("remove")]
        public IActionResult RemoveFromCart(CartDTO cartDTO)
        {
            var result = _cartService.RemoveFromCart(cartDTO);
            if(result) return Ok("Cart Items Removed...");
            return BadRequest("Could not remove item");
        }
    }
}