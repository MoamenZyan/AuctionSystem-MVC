using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.Domain.Interfaces.RepositoriesInterfaces;
using AuctionSystemApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Infrastructure.Repositories
{
    public class UserOTPRepository : IRepository<UserOTP>
    {
        private readonly AppDbContext _context;
        public UserOTPRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserOTP?> AddAsync(UserOTP entity)
        {
            try
            {
                await _context.UsersOTP.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
                return true;

            try
            {

                _context.UsersOTP.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public List<UserOTP>? Filter(Func<UserOTP, bool> filter)
        {
            return _context.UsersOTP.Where(filter).ToList();
        }

        public async Task<List<UserOTP>?> GetAll()
        {
            return await _context.UsersOTP.ToListAsync();
        }

        public async Task<UserOTP?> GetById(int id)
        {
            return await _context.UsersOTP.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<bool> UpdateAsync(UserOTP entity)
        {
            try
            {
                _context.UsersOTP.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
