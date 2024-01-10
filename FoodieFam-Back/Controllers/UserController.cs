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

    }
}
