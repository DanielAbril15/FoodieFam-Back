using FoodieFam_Back.DTOs.CategoryDto;
using FoodieFam_Back.DTOs.IngredientDto;
using FoodieFam_Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController:ControllerBase
    {
        private CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetCategories() =>
            await _categoryService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var categoryDto = await _categoryService.GetById(id);
            return categoryDto == null ? NotFound() : Ok(categoryDto);
        }
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> AddCategory(CategoryInsertDto categoryInsertDto)
        {
            var categoryDto = await _categoryService.Add(categoryInsertDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDto.CategoryId }, categoryDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(int id, CategoryPutDto categoryPutDto)
        {
            var categoryDto = await _categoryService.Update(id, categoryPutDto);

            return categoryDto == null ? NotFound() : Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDto>> DeleteCategory(int id)
        {
            var category = await _categoryService.Delete(id);
            if (category == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
