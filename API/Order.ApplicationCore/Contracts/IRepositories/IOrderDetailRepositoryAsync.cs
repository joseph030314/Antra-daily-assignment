using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.IRepositories
{
    public interface IOrderDetailRepositoryAsync : IRepositoryAsync<OrderDetail>
    {
    }
}
