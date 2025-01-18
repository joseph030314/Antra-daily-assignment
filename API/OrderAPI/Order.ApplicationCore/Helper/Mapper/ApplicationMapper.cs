using AutoMapper;
using Order.ApplicationCore.Models.Request;
using Order.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.ApplicationCore.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Entities.Order, OrderRequestModel>().ReverseMap();
            CreateMap<Entities.Order, OrderResponseModel>().ReverseMap();
        }
    }
}
