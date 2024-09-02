using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Interfaces.ServicesInterfaces
{
    public interface ICommentService
    {
        Task<bool> AddComment(Dictionary<string, string> comment);
        Task<bool> DeleteComment(int commentId);
        Task<bool> UpdateComment(int commentId, Dictionary<string, string> comment);
        List<Comment>? GetAuctionComments(int auctionId);
    }
}
