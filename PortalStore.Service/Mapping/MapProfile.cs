using AutoMapper;
using PortalStore.Core;
using PortalStore.Core.Dtos;
using PortalStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<BaseEntity, BaseEntityDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Sku, SkuDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemWithNavigationPropertiesDto>();
        }
    }
}
