using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.ApplicationCore.Contracts.IRepositories
{
    public interface IOrderRepositoryAsync : IRepositoryAsync<Entities.Order>
    {
        Task<IEnumerable<Entities.Order>> GetOrdersByCustomerIdAsync(int customerId);
    }
}
