using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Entities
{
    public class AuctionUser
    {
        public int AuctionId { get; set; }
        public int UserId { get; set; }
        public decimal CurrentBid { get; set; }
        public DateTime LastBid { get; set; }

        public Auction Auction { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
