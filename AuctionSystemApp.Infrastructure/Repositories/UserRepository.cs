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
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AddAsync(User entity)
        {
            try
            {
                await _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public List<User>? Filter(Func<User, bool> filter)
        {
            return _context.Users.Where(filter).ToList();
        }

        public async Task<List<User>?> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {

            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
            
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            try
            {
                _context.Users.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
