using Order.ApplicationCore.Interfaces;
using Order.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositoryAsync _orderRepository;

        public OrderService(IOrderRepositoryAsync orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order.ApplicationCore.Entities.Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }


        public async Task<Order.ApplicationCore.Entities.Order> GetOrderByCustomerIdAsync(int customerId)
        {
            return await _orderRepository.GetOrderByCustomerIdAsync(customerId);
        }

        public async Task AddOrderAsync(Order.ApplicationCore.Entities.Order order)
        {
            await _orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(Order.ApplicationCore.Entities.Order order)
        {
            await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
        }

    }
}
