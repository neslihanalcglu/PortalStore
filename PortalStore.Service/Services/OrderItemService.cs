using AutoMapper;
using PortalStore.Core;
using PortalStore.Core.Dtos;
using PortalStore.Core.Repositories;
using PortalStore.Core.Services;
using PortalStore.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Service.Services
{
    public class OrderItemService : Service<OrderItem>, IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;
        public OrderItemService(IGenericRepository<OrderItem> repository, IUnitOfWork unitOfWork, IOrderItemRepository orderItemRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<OrderItemWithNavigationPropertiesDto>>> GetListWithNavigationPropertiesAsync()
        {
            var orderItems = await _orderItemRepository.GetListWithNavigationPropertiesAsync();
            var orderItemDtos = _mapper.Map<List<OrderItemWithNavigationPropertiesDto>>(orderItems);

            return CustomResponseDto<List<OrderItemWithNavigationPropertiesDto>>.Success(200, orderItemDtos);
        }

        public async Task<CustomResponseDto<OrderItemWithNavigationPropertiesDto>> GetWithNavigationPropertieAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetWithNavigationPropertieAsync(id);
            var orderItemDto = _mapper.Map<OrderItemWithNavigationPropertiesDto>(orderItem);
            return CustomResponseDto<OrderItemWithNavigationPropertiesDto>.Success(200, orderItemDto);
        }
    }
}
