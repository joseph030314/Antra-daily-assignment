using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.IRepositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepositoryAsync : BaseRepositoryAsync<Order.ApplicationCore.Entities.Order>, IOrderRepositoryAsync
    {
        private readonly OrderDbContext context;
        public OrderRepositoryAsync(OrderDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order.ApplicationCore.Entities.Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await context.Orders.Where(o => o.CustomerId == customerId)
                .Include(o => o.OrderDetails)
                .ToListAsync();
        }
    }
}
