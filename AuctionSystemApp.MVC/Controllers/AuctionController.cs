using AuctionSystemApp.Application.ApplicationServices;
using AuctionSystemApp.Application.Interfaces;
using AuctionSystemApp.MVC.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystemApp.MVC.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuctionController : Controller
    {
        private readonly IAuctionAppService _auctionAppService;
        private readonly IUserAppService _userAppService;
        private readonly ICommentAppService _commentAppService;
        public AuctionController(IAuctionAppService auctionAppService,
                                IUserAppService userAppService,
                                ICommentAppService commentAppService)
        {
            _auctionAppService = auctionAppService;
            _userAppService = userAppService;
            _commentAppService = commentAppService;
        }
        public async Task<IActionResult> Index(int id)
        {
            if (id == 0)
                return RedirectToAction("Index", "Home");

            ViewData["user"] = await _userAppService.GetCurrentUserInfo(Convert.ToInt32(User.Claims.First().Value));
            ViewData["Auction"] = await _auctionAppService.GetAuctionById(id);
            ViewData["Comments"] = _commentAppService.GetAuctionComments(id);
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAuctions()
        {
            var auctions = await _auctionAppService.GetAllAuctions();
            ViewData["Auctions"] = auctions;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuction(AuctionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Dictionary<string, string> auctionInfo = new Dictionary<string, string>();
                auctionInfo.Add("Name", model.Name);
                auctionInfo.Add("Description", model.Description);
                auctionInfo.Add("From", Convert.ToString(model.From));
                auctionInfo.Add("To", Convert.ToString(model.To));

                var result = await _auctionAppService.CreateAuction(auctionInfo, Convert.ToInt32(User.Claims.First().Value), model.AuctionPhoto);
            }
            return View("Create");
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> AddBidToAuction(AuctionUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _auctionAppService.AddBidToAuction(Convert.ToInt32(User.Claims.First().Value), model.AuctionId, model.Bid);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
