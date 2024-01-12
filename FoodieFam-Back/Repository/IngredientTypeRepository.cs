using FoodieFam_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Repository
{
    public class IngredientTypeRepository: IRepositoryInt<IngredientType>
    {
        private FoodieFamContext _context;

        public IngredientTypeRepository(FoodieFamContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IngredientType>> Get() =>
            await _context.IngredientTypes.ToListAsync();


        public async Task<IngredientType> GetById(int id) =>
            await _context.IngredientTypes.FindAsync(id);

        public async Task Add(IngredientType ingredientType) =>
            await _context.IngredientTypes.AddAsync(ingredientType);

        public void Update(IngredientType ingredientType)
        {
            _context.IngredientTypes.Attach(ingredientType);
            _context.IngredientTypes.Entry(ingredientType).State = EntityState.Modified;
        }

        public void Delete(IngredientType ingredientType) =>
            _context.IngredientTypes.Remove(ingredientType);

        public async Task Save() =>
            await _context.SaveChangesAsync();

    }
}
