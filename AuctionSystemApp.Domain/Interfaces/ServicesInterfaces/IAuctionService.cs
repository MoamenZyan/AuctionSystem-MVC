using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Interfaces.ServicesInterfaces
{
    public interface IAuctionService
    {
        Task<bool> CreateAuction(Dictionary<string, string> auctionInfo);
        Task<bool> DeleteAuction(int auctionId);
        Task<List<Auction>?> GetAllAuctions();
        Task<Auction?> GetAuctionById(int auctionId);
        List<Auction>? GetAllUserAuctions(int userId);
        Task<bool> AddUserToAuction(int userId, int auctionId, decimal currentBid);
        Task<bool> UpdateUserAuction(AuctionUser auctionUser);
        Task<AuctionUser?> GetUserJoinedAuction(int userId, int auctionId); 
        Task<bool> CheckAuctionDeadline(int auctionId);
    }
}
