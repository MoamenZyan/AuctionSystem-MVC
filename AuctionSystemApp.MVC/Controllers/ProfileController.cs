using AuctionSystemApp.Application.DTOs;
using AuctionSystemApp.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystemApp.MVC.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : Controller
    {
        private readonly IUserAppService _userAppService;
        public ProfileController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public async Task<IActionResult> Index()
        {
            UserDto? user = await _userAppService.GetCurrentUserInfo(Convert.ToInt32(User.Claims.First().Value));
            List<AuctionDto>? auctions = _userAppService.GetUserAuctions(Convert.ToInt32(User.Claims.First().Value));
            ViewData["user"] = user;
            ViewData["userAuctions"] = auctions;
            return View();
        }
    }
}
