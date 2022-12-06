using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core.Dtos;
using PortalStore.Core;
using PortalStore.Core.Services;
using PortalStore.Service.Services;

namespace PortalStore.API.Controllers
{
    public class OrdersController : CustomBaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var orders = await _orderService.GetAllAsync();
            if (orders.ToList().Count == 0)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            }
            var orderDtos = _mapper.Map<List<OrderDto>>(orders.ToList());
            return CreateActionResult(CustomResponseDto<List<OrderDto>>.Success(200, orderDtos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            var orderDto = _mapper.Map<OrderDto>(order);
            return CreateActionResult(CustomResponseDto<OrderDto>.Success(200, orderDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderDto input)
        {
            var order = await _orderService.AddAsync(_mapper.Map<Order>(input));
            var orderDto = _mapper.Map<OrderDto>(order);
            return CreateActionResult(CustomResponseDto<OrderDto>.Success(201, orderDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(OrderDto input)
        {
            await _orderService.UpdateAsync(_mapper.Map<Order>(input));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Bu Id değerine ait bir veri bulunmamaktadır.Geçerli bir Id değeri giriniz."));
            }
            await _orderService.RemoveAsync(_mapper.Map<Order>(order));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
