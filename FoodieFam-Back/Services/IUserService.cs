using FoodieFam_Back.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUserById(Guid id);
        Task<UserDto> AddUser(UserInsertDto userInsertDto);
        Task<UserDto> UpdateUser(Guid id, UserPutDto userPutDto);
        Task<UserDto> DeleteUser(Guid id);
    }
}
