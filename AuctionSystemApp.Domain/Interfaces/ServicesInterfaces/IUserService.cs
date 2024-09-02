using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AuctionSystemApp.Domain.Interfaces.ServicesInterfaces
{
    public interface IUserService
    {
        Task<User?> CreateUser(Dictionary<string, string> userInfo);
        User? GetUserByHisEmail(string email);
        Task<User?> GetUserByHisId(int id);
    }
}
