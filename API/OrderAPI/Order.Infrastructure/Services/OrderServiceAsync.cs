using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Order.ApplicationCore.Contracts.IRepositories;
using Order.ApplicationCore.Contracts.IServices;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models.Request;
using Order.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Services
{
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IOrderRepositoryAsync orderRepository;
        private readonly IMapper mapper;
        public OrderServiceAsync(IOrderRepositoryAsync orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<int> DeleteOrder(int id)
        {
            return await orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllOrders()
        {
            return mapper.Map<IEnumerable<OrderResponseModel>>(await orderRepository.GetAllAsync());
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByCustomerId(int customerId)
        {
            return mapper.Map<IEnumerable<OrderResponseModel>>(await orderRepository.GetOrdersByCustomerIdAsync(customerId));
        }

        public async Task<OrderResponseModel?> GetOrderById(int id)
        {
            return mapper.Map<OrderResponseModel>(await orderRepository.GetByIdAsync(id));
        }

        public async Task<int> InsertOrder(OrderRequestModel model)
        {
            var order = mapper.Map<Order.ApplicationCore.Entities.Order>(model);
            return await orderRepository.InsertAsync(order);
        }

        public async Task<int> UpdateOrder(OrderRequestModel model, int id)
        {
            if (id == model.Id)
            {
                var order = mapper.Map<Order.ApplicationCore.Entities.Order>(model);
                return await orderRepository.UpdateAsync(order);
            }
            return 0;
        }
    }
}
