using AuctionSystemApp.Application.Interfaces;
using AuctionSystemApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuctionSystemApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly IAuctionAppService _auctionAppService;

        public HomeController(IUserAppService userAppService, IAuctionAppService auctionAppService)
        {
            _userAppService = userAppService;
            _auctionAppService = auctionAppService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity!.IsAuthenticated)
            {
                var user = await _userAppService.GetCurrentUserInfo(Convert.ToInt32(User.Claims.First().Value));
                ViewData["user"] = user;
            }
                var auctions = await _auctionAppService.GetAllAuctions();
                ViewData["auctions"] = auctions;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
