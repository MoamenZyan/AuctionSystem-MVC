using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentContent { get; set; } = null!;
        public int UserId { get; set; }
        public int AuctionId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;
        public Auction Auction { get; set; } = null!;
    }
}
