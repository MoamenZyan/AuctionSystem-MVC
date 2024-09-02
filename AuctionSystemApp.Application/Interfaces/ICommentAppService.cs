using AuctionSystemApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.Interfaces
{
    public interface ICommentAppService
    {
        Task<bool> AddComment(Dictionary<string, string> body);
        Task<bool> DeleteComment(int commentId);
        Task<bool> UpdateComment(int commentId,  Dictionary<string, string> body);
        List<CommentDto>? GetAuctionComments(int auctionId);
    }
}
