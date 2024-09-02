using AuctionSystemApp.Application.DTOs;
using AuctionSystemApp.Application.Interfaces;
using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.MVC.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystemApp.MVC.Controllers
{
    [AllowAnonymous]
    public class SignupController : Controller
    {
        private readonly IUserAppService _userAppService;
        public SignupController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAppService.CreateNewUser(model.ToDictionary(), model.UserPhoto);
                if (result == null)
                    ModelState.AddModelError(string.Empty, "User creation failed. Please try again.");
                return RedirectToAction("Index", "Home");
            }
            return NoContent();
        }
    }
}
