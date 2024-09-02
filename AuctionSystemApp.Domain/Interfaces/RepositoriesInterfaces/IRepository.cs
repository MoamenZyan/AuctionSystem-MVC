using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Interfaces.RepositoriesInterfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>?> GetAll();
        Task<T?> GetById(int id);
        Task<T?> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        List<T>? Filter(Func<T, bool> filter);
    }
}
