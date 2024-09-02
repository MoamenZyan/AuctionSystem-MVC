using AuctionSystemApp.Application.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<UserDto?> CreateNewUser(Dictionary<string, string> userInfo, IFormFile photo);
        Task<bool> SendUserOTP(string email);
        Task<string?> VerifyUserOTP(string email, string otp);
        Task<UserDto?> GetCurrentUserInfo(int userId); 
        List<AuctionDto>? GetUserAuctions(int userId);
    }
}
