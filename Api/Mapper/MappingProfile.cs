using AutoMapper;
using Roxosoft.Orders.Api.DAL.Dto;
using Roxosoft.Orders.Contracts.Data;

namespace Roxosoft.Orders.Api.Mapper {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<ProductDto, Product>();
            CreateMap<OrderDto, Order>()
                .ForMember(e => e.Products, e => e.Ignore());
        }
    }
}