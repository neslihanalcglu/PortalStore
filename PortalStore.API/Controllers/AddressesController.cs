using AutoMapper;
using MernisService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core.Dtos;
using PortalStore.Core;
using PortalStore.Core.Services;
using PortalStore.Service.Services;
using PortalStore.Core.Models;

namespace PortalStore.API.Controllers
{
    public class AddressesController : CustomBaseController
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressesController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var addresses = await _addressService.GetAllAsync();
            if (addresses.ToList().Count == 0)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            }
            var addressDtos = _mapper.Map<List<AddressDto>>(addresses.ToList());
            return CreateActionResult(CustomResponseDto<List<AddressDto>>.Success(200, addressDtos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            var addressDto = _mapper.Map<AddressDto>(address);
            return CreateActionResult(CustomResponseDto<AddressDto>.Success(200, addressDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddressDto input)
        {
            var address = await _addressService.AddAsync(_mapper.Map<Address>(input));
            var addressDto = _mapper.Map<AddressDto>(address);
            return CreateActionResult(CustomResponseDto<AddressDto>.Success(201, addressDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(AddressDto input)
        {
            await _addressService.UpdateAsync(_mapper.Map<Address>(input));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            if (address == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Bu Id değerine ait bir veri bulunmamaktadır.Geçerli bir Id değeri giriniz."));
            }
            await _addressService.RemoveAsync(_mapper.Map<Address>(address));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
