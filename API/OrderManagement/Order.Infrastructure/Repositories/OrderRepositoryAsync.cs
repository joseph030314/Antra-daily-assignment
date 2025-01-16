using Order.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Interfaces;
using Order.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
namespace Order.Infrastructure.Repositories
{
    public class OrderRepositoryAsync(OrderDbContext context) : IOrderRepositoryAsync
    {
        private readonly OrderDbContext _context = context;

        public async Task<IEnumerable<Order.ApplicationCore.Entities.Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
        }

        public async Task<List<ApplicationCore.Entities.Order>> GetOrderByCustomerIdAsync(int customerId)
        {
            return await _context.Set<ApplicationCore.Entities.Order>()
                                 .Where(order => order.CustomerId == customerId)
                                 .ToListAsync();
        }


        public async Task AddOrderAsync(Order.ApplicationCore.Entities.Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order.ApplicationCore.Entities.Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        Task<ApplicationCore.Entities.Order> IOrderRepositoryAsync.GetOrderByCustomerIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}