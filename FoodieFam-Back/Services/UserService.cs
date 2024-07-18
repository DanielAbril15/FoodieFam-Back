using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using FoodieFam_Back.DTOs.UserDto;

namespace FoodieFam_Back.Services
{
    public class UserService : ICommonGuidService<UserDto, UserInsertDto, UserPutDto>
    {
       
        private IRepositoryGuid<User> _userRepository;

        //Funcion que encripta la password
        private string encryptPass(string pass)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(pass));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            
            return sb.ToString();
        }

        public UserService(
            IRepositoryGuid<User> userRepository
            )
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> Get()
        {
            var users = await _userRepository.Get();

            return users.Select(user => new UserDto
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
            });
        }

             

        public async Task<UserDto> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
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

        public async Task<UserDto> Add(UserInsertDto userInsertDto)
        {
            var user = new User
            {
                Name = userInsertDto.Name,
                LastName = userInsertDto.LastName,
                Email = userInsertDto.Email,
                Password = encryptPass(userInsertDto.Password),
                DateCreated = DateTime.UtcNow
            };
            Console.WriteLine(userInsertDto.Email);
            Console.WriteLine(user.Email);
            var userExist = await _userRepository.UserExistsByEmailAsync(userInsertDto.Email);
            Console.WriteLine(userExist);

            //valida si el usuario ya fue creado por medio del email pues este debe ser unico
            if (userExist ) {
                return null;
            }
            else
            {
            //Menciona que habra una insercion en la DB
            await _userRepository.Add(user);

            //Se guardan los cambios en la DB
            await _userRepository.Save();

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
        }

        public async Task<UserDto> Update(Guid id, UserPutDto userPutDto)
        {
            var user = await _userRepository.GetById(id);
            if (user != null)
            {

                user.Name = userPutDto.Name;
                user.LastName = userPutDto.LastName;
                user.Email = userPutDto.Email;
                user.Password = userPutDto.Password;
                _userRepository.Update(user);
                await _userRepository.Save();

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

        public async Task<UserDto> Delete(Guid id)
        {
            var user = await _userRepository.GetById(id);
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
                _userRepository.Delete(user);
                await _userRepository.Save();

                return userDto;
            }
            return null;
        }
    }
}
