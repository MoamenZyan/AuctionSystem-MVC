using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Interfaces.RepositoriesInterfaces
{
    public interface IJunctionRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(int id1, int id2);
        Task<T?> GetByIds(int id1, int id2);
        Task<bool> UpdateAsync(T entity);
        Task<List<T>?> GetAll(int id);
    }
}
