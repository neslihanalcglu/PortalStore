using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core.Dtos;
using PortalStore.Core;
using PortalStore.Core.Services;
using PortalStore.Service.Services;
using AutoMapper;

namespace PortalStore.API.Controllers
{
    public class OrderItemsController : CustomBaseController
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }


        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var orderItems = await _orderItemService.GetAllAsync();
            if (orderItems.ToList().Count == 0)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            }
            var orderItemDtos = _mapper.Map<List<OrderItemDto>>(orderItems.ToList());
            return CreateActionResult(CustomResponseDto<List<OrderItemDto>>.Success(200, orderItemDtos));
        }

        [HttpGet("get-list-with-navigation-properties")]
        public async Task<IActionResult> GetListWithNavigationPropertiesAsync()
        {
            return CreateActionResult(await _orderItemService.GetListWithNavigationPropertiesAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var orderItem = await _orderItemService.GetByIdAsync(id);
            var orderItemDto = _mapper.Map<OrderItemDto>(orderItem);
            return CreateActionResult(CustomResponseDto<OrderItemDto>.Success(200, orderItemDto));
        }

        [HttpGet]
        [Route("get-with-navigation-properties/{id}")]
        public async Task<IActionResult> GetWithNavigationPropertiesAsync(int id)
        {
            return CreateActionResult(await _orderItemService.GetWithNavigationPropertieAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderItemDto orderItemDto)
        {
            var orderItem = await _orderItemService.AddAsync(_mapper.Map<OrderItem>(orderItemDto));
            var orderItemCreateDto = _mapper.Map<OrderItemDto>(orderItem);
            return CreateActionResult(CustomResponseDto<OrderItemDto>.Success(201, orderItemCreateDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(OrderItemDto orderItemDto)
        {
            await _orderItemService.UpdateAsync(_mapper.Map<OrderItem>(orderItemDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var orderItem = await _orderItemService.GetByIdAsync(id);
            if (orderItem == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Bu Id değerine ait bir veri bulunmamaktadır.Geçerli bir Id değeri giriniz."));
            }
            await _orderItemService.RemoveAsync(_mapper.Map<OrderItem>(orderItem));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
