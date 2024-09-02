using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Interfaces.ServicesInterfaces
{
    public interface IOtpService
    {
        Task<UserOTP> CreateUserOTP(int userId);
        Task<UserOTP?> GetOtpByUserId(int userId);
        Task<bool> UpdateUserOTP(UserOTP userOTP);
        Task<bool> VerfiyOTP(string Otp, int userId);
    }
}
