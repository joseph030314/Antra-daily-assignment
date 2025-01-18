using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.ApplicationCore.Contracts.IRepositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<int> InsertAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
