using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Factories
{
    public class AuctionUserFactory
    {
        public static AuctionUser CreateAuctionUser(int UserId, int AuctionId, decimal currentBid)
        {
            AuctionUser auctionUser = new AuctionUser()
            {
                UserId = UserId,
                AuctionId = AuctionId,
                CurrentBid = currentBid,
                LastBid = DateTime.Now,
            };
            return auctionUser;
        }
    }
}
