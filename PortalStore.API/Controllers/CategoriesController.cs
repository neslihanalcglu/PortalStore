using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Core;
using PortalStore.Core.Dtos;
using PortalStore.Core.Models;
using PortalStore.Core.Services;
using PortalStore.Service.Services;

namespace PortalStore.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper = null)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            if (categories.ToList().Count == 0)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            }
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoryDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryDto input)
        {
            var category = await _categoryService.AddAsync(_mapper.Map<Category>(input));
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categoryDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CategoryDto input)
        {
            await _categoryService.UpdateAsync(_mapper.Map<Category>(input));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Bu Id değerine ait bir veri bulunmamaktadır.Geçerli bir Id değeri giriniz."));
            }
            await _categoryService.RemoveAsync(_mapper.Map<Category>(category));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
