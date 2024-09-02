using AuctionSystemApp.Application.DTOs;
using AuctionSystemApp.Application.DTOsFactories;
using AuctionSystemApp.Application.Interfaces;
using AuctionSystemApp.Application.Interfaces.StrategiesInterfaces;
using AuctionSystemApp.Domain.Interfaces.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.ApplicationServices
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService _commentService;
        private readonly IUserAppService _userAppService;
        private readonly IAuctionService _auctionService;
        private readonly INotificationContext _notificationContext;
        private readonly IUserAddedCommentOnAuctionEmailStrategy _userAddedCommentOnAuctionEmailStrategy;
        public CommentAppService(ICommentService commentService, 
                                    IUserAppService userAppService,
                                    IUserAddedCommentOnAuctionEmailStrategy userAddedCommentOnAuctionEmailStrategy,
                                    INotificationContext notificationContext,
                                    IAuctionService auctionService)
        {
            _commentService = commentService;
            _userAppService = userAppService;
            _userAddedCommentOnAuctionEmailStrategy = userAddedCommentOnAuctionEmailStrategy;
            _notificationContext = notificationContext;
            _auctionService = auctionService;
        }
        public async Task<bool> AddComment(Dictionary<string, string> body)
        {
            var result = await _commentService.AddComment(body);
            if (result == false)
                return false;

            var commentedUser = await _userAppService.GetCurrentUserInfo(Convert.ToInt32(body["UserId"]));
            var auctionUser = (await _auctionService.GetAuctionById(Convert.ToInt32(body["AuctionId"])))?.User;
            if (commentedUser == null || auctionUser == null)
                return false;

            _notificationContext.SetNotificationStrategy(_userAddedCommentOnAuctionEmailStrategy);
            Dictionary<string, string> emailBody = new Dictionary<string, string>();
            emailBody.Add("JoinedUser", commentedUser.Fname);
            await _notificationContext.Send(auctionUser.Fname, auctionUser.Email, emailBody);

            return true;
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            var result = await _commentService.DeleteComment(commentId);
            return result;
        }

        public List<CommentDto>? GetAuctionComments(int auctionId)
        {
            var comments = _commentService.GetAuctionComments(auctionId);
            return comments?.Select(x => CommentDtoFactory.CreateCommentDto(x)).ToList();
        }

        public async Task<bool> UpdateComment(int commentId, Dictionary<string, string> body)
        {
            var result = await _commentService.UpdateComment(commentId, body);
            return result;
        }
    }
}
