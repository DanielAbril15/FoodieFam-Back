using FoodieFam_Back.DTOs;
using FoodieFam_Back.Models;
using FoodieFam_Back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }

        //Trae TODOS los Usuarios
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers() =>
            await _userService.GetUsers();

        //Trae UN Usuario
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid id)
        {
            var userDto = await _userService.GetUserById(id);

            return userDto == null ? NotFound() : Ok(userDto);
        }

        //Creacion Usuario
        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser(UserInsertDto userInsertDto)
        {
            var userDto = await _userService.AddUser(userInsertDto);

            return CreatedAtAction(nameof(GetUserById), new { id = userDto.UserId }, userDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdatedUser(Guid id, UserPutDto userPutDto)
        {
            var userDto = await _userService.UpdateUser(id, userPutDto);

            return userDto == null ? NotFound() : Ok(userDto);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(Guid id)
        {
            var user = await _userService.DeleteUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
