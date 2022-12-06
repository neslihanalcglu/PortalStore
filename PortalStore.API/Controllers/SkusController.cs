using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core.Dtos;
using PortalStore.Core;
using PortalStore.Core.Services;
using PortalStore.Service.Services;

namespace PortalStore.API.Controllers
{
    public class SkusController : CustomBaseController
    {
        private readonly ISkuService _skuService;
        private readonly IMapper _mapper;

        public SkusController(ISkuService skuService, IMapper mapper)
        {
            _skuService = skuService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var skus = await _skuService.GetAllAsync();
            if (skus.ToList().Count == 0)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            }
            var skuDtos = _mapper.Map<List<SkuDto>>(skus.ToList());
            return CreateActionResult(CustomResponseDto<List<SkuDto>>.Success(200, skuDtos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var sku = await _skuService.GetByIdAsync(id);
            var skuDto = _mapper.Map<SkuDto>(sku);
            return CreateActionResult(CustomResponseDto<SkuDto>.Success(200, skuDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SkuDto input)
        {
            var sku = await _skuService.AddAsync(_mapper.Map<Sku>(input));
            var skuDto = _mapper.Map<SkuDto>(sku);
            return CreateActionResult(CustomResponseDto<SkuDto>.Success(201, skuDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(SkuDto input)
        {
            await _skuService.UpdateAsync(_mapper.Map<Sku>(input));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var sku = await _skuService.GetByIdAsync(id);
            if (sku == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Bu Id değerine ait bir veri bulunmamaktadır.Geçerli bir Id değeri giriniz."));
            }
            await _skuService.RemoveAsync(_mapper.Map<Sku>(sku));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
