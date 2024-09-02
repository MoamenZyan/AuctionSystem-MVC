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
    public class AuctionUserRepository : IJunctionRepository<AuctionUser>
    {
        private readonly AppDbContext _context;
        public AuctionUserRepository(AppDbContext context)
        {
            _context = context;    
        }
        public async Task<bool> AddAsync(AuctionUser entity)
        {
            try
            {
                await _context.AuctionUsers.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            } 
            
        }

        public async Task<bool> DeleteAsync(int id1, int id2)
        {
            var entity = await _context.AuctionUsers.FirstOrDefaultAsync(x => x.UserId == id1 && x.AuctionId == id2);
            if (entity == null)
                return true;

            try
            {
                _context.AuctionUsers.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<AuctionUser>?> GetAll(int id)
        {
            return await _context.AuctionUsers
                                .Include(x => x.User)
                                .Include(x => x.Auction)
                                .Where(x => x.AuctionId == id)
                                .AsNoTracking()
                                .ToListAsync();
        }

        public async Task<AuctionUser?> GetByIds(int id1, int id2)
        {
            var entity = await _context.AuctionUsers
                                    .Include(x => x.User)
                                    .Include(x => x.Auction)
                                    .FirstOrDefaultAsync(x => x.UserId == id1 && x.AuctionId == id2);
            return entity;
        }

        public async Task<bool> UpdateAsync(AuctionUser entity)
        {
            try
            {
                _context.AuctionUsers.Update(entity);
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
