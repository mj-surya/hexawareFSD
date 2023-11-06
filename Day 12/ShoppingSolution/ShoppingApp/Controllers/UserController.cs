using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;
using ShoppingApp.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Controllers
{
    
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserVewModel viewmodel)
        {
            var result = _userService.Register(viewmodel);
            if(result != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserVewModel viewmodel)
        {
            var result = _userService.Login(viewmodel);
            if(result != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "The user name or password is incorrect");
            return View();
        }
    }
}
