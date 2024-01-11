using FoodieFam_Back.DTOs;
using FoodieFam_Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private FoodieFamContext _context;
        public UserController(FoodieFamContext context)
        {
            _context = context;
        }

        //Trae TODOS los Usuarios
        [HttpGet]
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

        //Trae UN Usuario
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //Creacion Usuario
        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser(UserInsertDto userInsertDto)
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

            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, userDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdatedUser(Guid id, UserPutDto userPutDto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = userPutDto.Name;
            user.LastName = userPutDto.LastName;
            user.Email = userPutDto.Email;
            user.Password = userPutDto.Password;

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

            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
