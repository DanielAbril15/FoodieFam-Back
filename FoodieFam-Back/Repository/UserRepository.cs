using FoodieFam_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Repository
{
    public class UserRepository : IRepositoryGuid<User>
    {
        private FoodieFamContext _context;

        public UserRepository(FoodieFamContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> Get() =>
            await _context.Users.ToListAsync();

        public async Task<bool> UserExistsByEmailAsync(string email) =>
            await _context.Users.AnyAsync(user => user.Email == email);
        public async Task<User> GetUserByEmail(string email) =>
            await _context.Users.FindAsync(email);

        public async Task<User> GetById(Guid id) =>
            await _context.Users.FindAsync(id);

        public async Task Add(User user) =>
            await _context.Users.AddAsync(user);

        public void Update(User user)
        {
            _context.Users.Attach(user);
            _context.Users.Entry(user).State = EntityState.Modified;
        }

        public void Delete(User user) => 
            _context.Users.Remove(user);



        public async Task Save() =>
            await _context.SaveChangesAsync();

    }
}
