using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models.Request;
using Order.ApplicationCore.Models.Response;

namespace Order.ApplicationCore.Contracts.IServices
{
    public interface IOrderServiceAsync
    {
        Task<int> InsertOrder(OrderRequestModel model);
        Task<int> DeleteOrder(int id);
        Task<int> UpdateOrder(OrderRequestModel model, int id);
        Task<OrderResponseModel?> GetOrderById(int id);
        Task<IEnumerable<OrderResponseModel>> GetAllOrders();
        Task<IEnumerable<OrderResponseModel>> GetOrdersByCustomerId(int customerId);
    }
}
