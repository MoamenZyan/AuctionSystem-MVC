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
    public class CommentRepository : IRepository<Comment>
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Comment?> AddAsync(Comment entity)
        {
            try
            {
                await _context.Comments.AddAsync(entity);
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
                _context.Comments.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public List<Comment>? Filter(Func<Comment, bool> filter)
        {
            return _context.Comments
                        .Include(x => x.User)
                        .Include(x => x.Auction)
                        .AsNoTracking()
                        .Where(filter)
                        .ToList();
        }

        public async Task<List<Comment>?> GetAll()
        {
            return await _context.Comments
                        .Include(x => x.User)
                        .Include(x => x.Auction)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Comment?> GetById(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Comment entity)
        {
            try
            {
                _context.Comments.Update(entity);
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
