using FoodieFam_Back.DTOs;
using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Services
{
    public class UserService : ICommonGuidService<UserDto, UserInsertDto, UserPutDto>
    {
       
        private IRepositoryGuid<User> _userRepository;

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
                Password = userInsertDto.Password,
                DateCreated = DateTime.UtcNow
            };
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
