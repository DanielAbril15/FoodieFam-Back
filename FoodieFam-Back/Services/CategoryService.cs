using FoodieFam_Back.DTOs.CategoryDto;
using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;

namespace FoodieFam_Back.Services
{
    public class CategoryService : ICommonIntService<CategoryDto, CategoryInsertDto, CategoryPutDto>
    {
        private CategoryRepository _categoryRepository;
        public CategoryService(
            CategoryRepository categoryRepository
            ) 
        {
            _categoryRepository = categoryRepository;    
        }
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            var category = await _categoryRepository.Get();

            return category.Select(category => new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
            });
        }
        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category!=null)
            {
                var categoryDto = new CategoryDto
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                };
                return categoryDto;
            }
            return null;
        }
        public async Task<CategoryDto> Add(CategoryInsertDto categoryInsertDto)
        {
            var category = new Category
            {
                Name = categoryInsertDto.Name
            };
            await _categoryRepository.Add(category);
            await _categoryRepository.Save();

            var categoryDto = new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
            };
            return categoryDto;
        }

        public async Task<CategoryDto> Update(int id, CategoryPutDto categoryPutDto)
        {

            var category = await _categoryRepository.GetCategoryById(id);
            if (category != null)
            {
                category.Name = categoryPutDto.Name;
                _categoryRepository.Update(category);
                await _categoryRepository.Save();

                var categoryDto = new CategoryDto
                {
                    CategoryId = category.CategoryId,
                    Name = categoryPutDto.Name,
                };
                return categoryDto;
            }
            return null;
        }
        public async Task<CategoryDto> Delete(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category != null)
            {
                var categoryDto = new CategoryDto
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                };
                _categoryRepository.Delete(category);
                await _categoryRepository.Save();
                return categoryDto;
            };
            return null;
        }

    }
}
