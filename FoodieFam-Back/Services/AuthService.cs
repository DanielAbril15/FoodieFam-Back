using FoodieFam_Back.DTOs.UserDto;
using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodieFam_Back.Services
{
    public class AuthService
    {
        private UserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public AuthService(UserRepository userRepository, IConfiguration configuration) 
        { 
            _userRepository = userRepository;
            _configuration = configuration;
        }


        public async Task<User> Login(UserLoginDto userLoginDto)
        {
            var user = await _userRepository.GetUserByEmail(userLoginDto.Email);
            
            if (user != null) 
            {
                //comprueba si la clave que ingreso es la misma que la de db
                if(BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Name, user.Email, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!
                ));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials                
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
