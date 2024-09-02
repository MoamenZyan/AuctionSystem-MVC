using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Entities
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TimeWindow AuctionTime { get; set; } = null!;
        public string PhotoPath { get; set; } = null!;
        public int UserId { get; set; }


        public User User { get; set; } = null!;
        public List<AuctionUser> JoinedUsers { get; set; } = new List<AuctionUser>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
