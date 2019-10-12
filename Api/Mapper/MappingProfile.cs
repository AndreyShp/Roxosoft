using System.Collections.Generic;
using AutoMapper;
using Roxosoft.Orders.Api.DAL.Dto;
using Roxosoft.Orders.Contracts.Data;

namespace Roxosoft.Orders.Api.Mapper {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<ProductDto, Product>();
            CreateMap<OrderProductDto, OrderProduct>()
                .ForMember(dest => dest.Product, opt => new Product { Id = 1, Name = "aa" });
            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts));
        }
    }
}