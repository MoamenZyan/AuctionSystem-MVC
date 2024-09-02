using AuctionSystemApp.Application.DTOs;
using AuctionSystemApp.Application.DTOsFactories;
using AuctionSystemApp.Application.Interfaces;
using AuctionSystemApp.Application.Interfaces.StrategiesInterfaces;
using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.Domain.Interfaces.ServicesInterfaces;
using AuctionSystemApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AuctionSystemApp.Application.ApplicationServices
{
    public class AuctionAppService : IAuctionAppService
    {
        private readonly IAuctionService _auctionService;
        private readonly IFileSystem _photoService;
        private readonly INotificationContext _notificationContext;
        private readonly IUserAppService _userAppService;
        private readonly IUserJoinedAuctionEmailStrategy _userJoinedAuctionEmailStrategy;
        public AuctionAppService(IAuctionService auctionService, 
                                IFileSystem photoService, 
                                INotificationContext notificationContext,
                                IUserJoinedAuctionEmailStrategy userJoinedAuctionEmailStrategy,
                                IUserAppService userAppService)
        {
            _auctionService = auctionService;
            _photoService = photoService;
            _notificationContext = notificationContext;
            _userJoinedAuctionEmailStrategy = userJoinedAuctionEmailStrategy;
            _userAppService = userAppService;
        }

        public async Task<bool> AddBidToAuction(int userId, int auctionId, decimal bid)
        {
            if (!await _auctionService.CheckAuctionDeadline(auctionId))
                return false;

            var auctionUser = await _auctionService.GetUserJoinedAuction(userId, auctionId);
            if (auctionUser == null)
            {
                var result = await _auctionService.AddUserToAuction(userId, auctionId, bid);
                if (!result)
                    return false;
            }
            else
            {
                auctionUser.CurrentBid = bid;
                auctionUser.LastBid = DateTime.Now;

                await _auctionService.UpdateUserAuction(auctionUser);
            }

            var action = await _auctionService.GetAuctionById(auctionId);
            var joinedUser = await _userAppService.GetCurrentUserInfo(userId);

            if (action == null || joinedUser == null) 
                return false;

            User auctionOwner = action.User;

            Dictionary<string, string> body = new Dictionary<string, string>();
            body.Add("JoinedUserName", joinedUser.Fname);
            body.Add("Bid", Convert.ToString(bid));
            body.Add("AuctionName", action.Name);

            _notificationContext.SetNotificationStrategy(_userJoinedAuctionEmailStrategy);
            await _userJoinedAuctionEmailStrategy.Send(auctionOwner.Fname, auctionOwner.Email, body);
            return true;
        }

        public async Task<bool> CreateAuction(Dictionary<string, string> auctionInfo, int userId, IFormFile photo)
        {
            if (userId == 0)
                return false;

            Guid guid = Guid.NewGuid();
            var photoPath = await _photoService.AddPhoto(guid, "auction", photo);

            if (photoPath == null) 
                return false;

            auctionInfo.Add("UserId", Convert.ToString(userId));
            auctionInfo.Add("PhotoPath", photoPath);
            var result = await _auctionService.CreateAuction(auctionInfo);

            return result;
        }

        public async Task<bool> DeleteAuction(int auctionId, int userId)
        {
            Auction? auction = await _auctionService.GetAuctionById(auctionId);
            if (auction == null)
                return true;

            if (auction.UserId != userId)
                return false;

            return await _auctionService.DeleteAuction(auctionId);
        }

        public async Task<List<AuctionDto>?> GetAllAuctions()
        {
            List<Auction>? auctions = await _auctionService.GetAllAuctions();
            return auctions?.Select(x => AuctionDtoFactory.CreateAuctionDto(x)).ToList();
        }

        public async Task<AuctionDto?> GetAuctionById(int auctionId)
        {
            Auction? auction = await _auctionService.GetAuctionById(auctionId);
            if (auction == null) 
                return null;

            return AuctionDtoFactory.CreateAuctionDto(auction);
        }
    }
}
