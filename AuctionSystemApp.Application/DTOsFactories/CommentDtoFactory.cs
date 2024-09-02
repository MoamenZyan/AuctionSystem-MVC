using AuctionSystemApp.Application.DTOs;
using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.DTOsFactories
{
    public class CommentDtoFactory
    {
        public static CommentDto CreateCommentDto(Comment comment)
        {
            return new CommentDto(comment);
        }
    }
}
