using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string PhotoPath { get; set; } = null!;

        public List<Auction> OwnedAuctions { get; set; } = new List<Auction>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<AuctionUser> JoinedAuctions { get; set; } = new List<AuctionUser>();
    }
}
