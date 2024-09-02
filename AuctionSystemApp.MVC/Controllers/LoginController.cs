using AuctionSystemApp.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystemApp.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUserAppService _userAppService;
        public LoginController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Append("AuthJwt", "", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(-1)
            });

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> SendUserOTP([FromForm] string email)
        {
            var result = await _userAppService.SendUserOTP(email);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyOtp([FromForm] string email, [FromForm] string otp)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAppService.VerifyUserOTP(email, otp);
                if (result == null)
                    return Unauthorized();
                Console.WriteLine(result);
                Response.Cookies.Append("AuthJwt", result, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddHours(5)
                });

                return Redirect("/Home/Index");
            }
            return Unauthorized();
        }
    }
}
