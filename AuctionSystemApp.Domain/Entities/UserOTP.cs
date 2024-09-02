using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Entities
{
    public class UserOTP
    {
        public int Id { get; set; }
        public string OTP { get; set; } = null!;
        public DateTime Deadline { get; set; }
        public int UserId { get; set; }
    }
}
