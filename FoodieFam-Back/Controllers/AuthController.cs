using FoodieFam_Back.DTOs.UserDto;
using FoodieFam_Back.Models;
using FoodieFam_Back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthService _authService;
        public AuthController(AuthService authService )
        {
            _authService = authService;
        }



        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDto userLoginDto)
        {
            var userData = await _authService.Login(userLoginDto);
            if (userData == null) 
            {
                return Unauthorized(new { message = "Email or password is incorrect" });
            }
            else
            {
                var token = _authService.CreateToken(userData); 
                return Ok(token);
            }
        }



    }
}
