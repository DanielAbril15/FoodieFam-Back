using FoodieFam_Back.DTOs.UserDto;
using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;

namespace FoodieFam_Back.Services
{
    public class AuthService
    {
        private UserRepository _userRepository;

        public AuthService(UserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }


        public async Task<User> Login(UserLoginDto userLoginDto)
        {
            var user = await _userRepository.GetUserByEmail(userLoginDto.Email);
            
            if (user != null) 
            {
                if(BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }

    }
}
