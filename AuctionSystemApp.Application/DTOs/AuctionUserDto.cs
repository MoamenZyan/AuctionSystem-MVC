using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.DTOs
{
    public class AuctionUserDto
    {
        public string UserPhoto { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public decimal Bid { get; set; }
        public int UserId { get; set; }
        public int AuctionId { get; set; }
        public DateTime LastBid { get; set; }

        public AuctionUserDto(AuctionUser auctionUser)
        {
            UserId = auctionUser.UserId;
            AuctionId = auctionUser.AuctionId;
            UserName = $"{auctionUser.User.Fname} {auctionUser.User.Lname}";
            Bid = auctionUser.CurrentBid;
            UserPhoto = auctionUser.User.PhotoPath;
            LastBid = auctionUser.LastBid;
        }

    }
}
