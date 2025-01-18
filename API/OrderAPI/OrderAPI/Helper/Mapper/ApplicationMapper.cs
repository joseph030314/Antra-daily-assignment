using AutoMapper;
using Order.ApplicationCore.Models.Request;
using Order.ApplicationCore.Models.Response;

namespace Order.API.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Order.ApplicationCore.Entities.Order, OrderRequestModel>().ReverseMap();
            CreateMap<Order.ApplicationCore.Entities.Order, OrderResponseModel>().ReverseMap();
        }
    }
}
