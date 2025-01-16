using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Interfaces { 
public interface IOrderRepositoryAsync
{
    Task<IEnumerable<Order.ApplicationCore.Entities.Order>> GetAllOrdersAsync();
    Task<ApplicationCore.Entities.Order> GetOrderByCustomerIdAsync(int customerId);
    Task AddOrderAsync(Order.ApplicationCore.Entities.Order order);
    Task UpdateOrderAsync(Order.ApplicationCore.Entities.Order order);
    Task DeleteOrderAsync(int id);
}
}