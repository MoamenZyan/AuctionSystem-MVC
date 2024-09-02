using AuctionSystemApp.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace AuctionSystemApp.MVC.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("Comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentAppService _commentAppService;
        public CommentController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> CreateComment(int id)
        {
            var body = await Request.ReadFormAsync();
            Dictionary<string, string> comment = new Dictionary<string, string>();
            comment.Add("CommentContent", body["CommentContent"]!);
            comment.Add("AuctionId", Convert.ToString(id));
            comment.Add("UserId", User.Claims.First().Value);
            var result = await _commentAppService.AddComment(comment);
            return Ok();
        }
    }
}
