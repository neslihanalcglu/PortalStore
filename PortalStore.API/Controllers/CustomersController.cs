using AutoMapper;
using MernisService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core;
using PortalStore.Core.Dtos;
using PortalStore.Core.Services;

namespace PortalStore.API.Controllers
{
    public class CustomersController : CustomBaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController( IMapper mapper = null, ICustomerService customerService = null)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var customers = await _customerService.GetAllAsync();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customerDtos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customerDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomerDto input)
        {
            var client = new MernisService.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(input.TCID), input.FirstName, input.LastName, input.Birthdate.Year);
            var result = response.Body.TCKimlikNoDogrulaResult;
            if (!result)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Böyle bir kişi bulunmamaktadır."));
            }
            var customer = await _customerService.AddAsync(_mapper.Map<Customer>(input));
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, customerDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CustomerDto input)
        {
            await _customerService.UpdateAsync(_mapper.Map<Customer>(input));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Bu Id değerine ait bir müşteri bulunmamaktadır.Geçerli bir Id değeri giriniz."));
            }
            await _customerService.RemoveAsync(_mapper.Map<Customer>(customer));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
