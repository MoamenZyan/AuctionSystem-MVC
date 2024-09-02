using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.Domain.Factories;
using AuctionSystemApp.Domain.Interfaces.RepositoriesInterfaces;
using AuctionSystemApp.Domain.Interfaces.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // Create User & save it to database
        public async Task<User?> CreateUser(Dictionary<string, string> userInfo)
        {
            User user = UserFactory.CreateUser(userInfo);
            var result = await _userRepository.AddAsync(user);
            return result;
        }

        // Get user by his email
        public User? GetUserByHisEmail(string email)
        {
            var user = _userRepository.Filter(x => x.Email == email)?.FirstOrDefault();
            return user;
        }

        public async Task<User?> GetUserByHisId(int id)
        {
            return await _userRepository.GetById(id);
        }
    }
}
