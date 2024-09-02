using AuctionSystemApp.Application.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.Interfaces
{
    public interface IAuctionAppService
    {
        Task<bool> CreateAuction(Dictionary<string, string> auctionInfo, int userId, IFormFile photo);
        Task<bool> DeleteAuction(int auctionId, int userId);
        Task<List<AuctionDto>?> GetAllAuctions();
        Task<AuctionDto?> GetAuctionById(int auctionId);
        Task<bool> AddBidToAuction(int userId, int auctionId, decimal bid);
    }
}
