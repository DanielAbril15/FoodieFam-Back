using FoodieFam_Back.DTOs.RecipeDto;
using FoodieFam_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Repository
{
    public class RecipeRepository 
    {
        private FoodieFamContext _context;
        public RecipeRepository(FoodieFamContext context)
        {
            _context = context;
        }

        public async Task AddRecipe(Recipe recipe)=>        
            await _context.Recipes.AddAsync(recipe);


        public void Delete(Recipe recipe) =>
             _context.Recipes.Remove(recipe);

        public async Task<IEnumerable<Recipe>> GetAllREcipes() =>
            await _context.Recipes.ToListAsync();
        

        public async Task<Recipe> GetRecipeById(Guid id)=>
            await _context.Recipes.FindAsync(id);

        public async Task Save()=>
            await _context.SaveChangesAsync();

        public void UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Attach(recipe);
            _context.Recipes.Entry(recipe).State = EntityState.Modified;
        }


        
    }
}
