using FoodieFam_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Repository
{
    public class CategoryRepository
    {
        private FoodieFamContext _context;

        public CategoryRepository(FoodieFamContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Get() =>
            await _context.Categories.ToListAsync();

        public async Task<Category> GetCategoryById(int id)=>
            await _context.Categories.FindAsync(id);

        public async Task AddCategoryRecipe(CategoryRecipe categoryRecipe) =>
           await _context.CategoryRecipes.AddAsync(categoryRecipe);

        public async Task Add(Category category) =>
            await _context.Categories.AddAsync(category);
        public void Update(Category category)
        {
            _context.Categories.Attach(category);
            _context.Categories.Entry(category).State = EntityState.Modified;
        }
        public void Delete(Category category) =>
           _context.Categories.Remove(category);

        public async Task Save() =>
            await _context.SaveChangesAsync();
    }
}
