using FoodieFam_Back.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FoodieFam_Back.Repository
{
    public class IngredientRepository
    {
        private FoodieFamContext _context;

        public IngredientRepository(FoodieFamContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingredient>> Get() =>
            await _context.Ingredients.ToListAsync();

        public async Task<Ingredient> GetById(Guid id) =>
            await _context.Ingredients.FindAsync(id);

        public async Task Add(Ingredient ingredient) =>
            await _context.Ingredients.AddAsync(ingredient);

        public async Task AddUserIngredient(UserIngredient userIngredient) =>
            await _context.UserIngredients.AddAsync(userIngredient);

        public void Update(Ingredient ingredient)
        {
            _context.Ingredients.Attach(ingredient);
            _context.Ingredients.Entry(ingredient).State = EntityState.Modified;
        }

        public void Delete(Ingredient ingredient) =>
            _context.Ingredients.Remove(ingredient);

        public async Task Save() =>
            await _context.SaveChangesAsync();
    }
}
