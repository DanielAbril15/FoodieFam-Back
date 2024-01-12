using FoodieFam_Back.DTOs;
using FoodieFam_Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ICommonGuidService<UserDto, UserInsertDto, UserPutDto> _userService;
        public UserController(
          [FromKeyedServices("userService")] ICommonGuidService<UserDto, UserInsertDto, UserPutDto> userService)
        {
            _userService = userService;
        }

        //Trae TODOS los Usuarios
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers() =>
            await _userService.Get();

        //Trae UN Usuario
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid id)
        {
            var userDto = await _userService.GetById(id);

            return userDto == null ? NotFound() : Ok(userDto);
        }

        //Creacion Usuario
        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser(UserInsertDto userInsertDto)
        {
            var userDto = await _userService.Add(userInsertDto);

            return CreatedAtAction(nameof(GetUserById), new { id = userDto.UserId }, userDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdatedUser(Guid id, UserPutDto userPutDto)
        {
            var userDto = await _userService.Update(id, userPutDto);

            return userDto == null ? NotFound() : Ok(userDto);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(Guid id)
        {
            var user = await _userService.Delete(id);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
