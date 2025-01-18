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
    public class OrderDetailRepositoryAsync : BaseRepositoryAsync<OrderDetail>, IOrderDetailRepositoryAsync
    {
        public OrderDetailRepositoryAsync(OrderDbContext context) : base(context)
        {
        }
    }
}
