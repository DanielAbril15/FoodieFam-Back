using FoodieFam_Back.DTOs;
using FoodieFam_Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Services
{
    public class UserService : IUserService
    {
        private FoodieFamContext _context;

        public UserService(FoodieFamContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetUsers() =>
             await _context.Users.Select(user => new UserDto
             {
                 UserId = user.UserId,
                 Name = user.Name,
                 LastName = user.LastName,
                 Email = user.Email,
                 Password = user.Password,
                 Role = user.Role,
                 Status = user.Status,
                 IsVerified = user.IsVerified,
                 DateCreated = user.DateCreated
             }).ToListAsync();

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                var userDto = new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Role = user.Role,
                    Status = user.Status,
                    IsVerified = user.IsVerified,
                    DateCreated = user.DateCreated
                };
                return userDto;
            }
            return null;
        }

        public async Task<UserDto> AddUser(UserInsertDto userInsertDto)
        {
            var user = new User
            {
                Name = userInsertDto.Name,
                LastName = userInsertDto.LastName,
                Email = userInsertDto.Email,
                Password = userInsertDto.Password,
                DateCreated = DateTime.UtcNow
            };
            //Menciona que habra una insercion en la DB
            await _context.Users.AddAsync(user);

            //Se guardan los cambios en la DB
            await _context.SaveChangesAsync();

            var userDto = new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Status = user.Status,
                IsVerified = user.IsVerified,
                DateCreated = user.DateCreated
            };
            return userDto;
        }

        public async Task<UserDto> UpdateUser(Guid id, UserPutDto userPutDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {

                user.Name = userPutDto.Name;
                user.LastName = userPutDto.LastName;
                user.Email = userPutDto.Email;
                user.Password = userPutDto.Password;
                _context.SaveChanges();

                var userDto = new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Role = user.Role,
                    Status = user.Status,
                    IsVerified = user.IsVerified,
                    DateCreated = user.DateCreated
                };
                return userDto;
            }
            return null;
        }

        public async Task<UserDto> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user!= null)
            {
                var userDto = new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Role = user.Role,
                    Status = user.Status,
                    IsVerified = user.IsVerified,
                    DateCreated = user.DateCreated
                };
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return userDto;
            }
            return null;
        }
    }
}
