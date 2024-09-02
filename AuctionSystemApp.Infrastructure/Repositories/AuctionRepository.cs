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
    public class AuctionRepository : IRepository<Auction>
    {
        private readonly AppDbContext _context;
        public AuctionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Auction?> AddAsync(Auction entity)
        {
            try
            {
                await _context.Auctions.AddAsync(entity);
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
                _context.Auctions.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public List<Auction>? Filter(Func<Auction, bool> filter)
        {
            return _context.Auctions
                                .Include(x => x.User)
                                .Include(x => x.JoinedUsers)
                                .Where(filter).ToList();
        }

        public async Task<List<Auction>?> GetAll()
        {
            return await _context.Auctions
                                .Include(x => x.User)
                                .Include(x => x.JoinedUsers)
                                    .ThenInclude(x => x.User)
                                .ToListAsync();
        }

        public async Task<Auction?> GetById(int id)
        {
                var entity = await _context.Auctions
                                .Include(x => x.User)
                                .Include(x => x.JoinedUsers)
                                .FirstOrDefaultAsync(x => x.Id == id);
                return entity;
        }

        public async Task<bool> UpdateAsync(Auction entity)
        {
            try
            {
                _context.Auctions.Update(entity);
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
