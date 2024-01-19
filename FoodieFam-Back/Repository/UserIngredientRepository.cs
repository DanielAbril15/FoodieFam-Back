using FoodieFam_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Repository
{
    public class UserIngredientRepository
    {
        private FoodieFamContext _context;

        public UserIngredientRepository(FoodieFamContext context)
        {
            _context = context;
        }

        public async Task Add(UserIngredient userIngredient) =>
            await _context.UserIngredients.AddAsync(userIngredient);

        public async Task<IEnumerable<UserIngredient>> GetByUserId(Guid id) =>
            await _context.UserIngredients.Where(uI => uI.UserId == id).ToListAsync();

        public void Update(UserIngredient userIngredient)
        {
            _context.UserIngredients.Attach(userIngredient);
            _context.UserIngredients.Entry(userIngredient).State = EntityState.Modified;
        }

        public void Delete(UserIngredient userIngredient) =>
            _context.UserIngredients.Remove(userIngredient);



        public async Task Save() =>
            await _context.SaveChangesAsync();

    }
}
