using FoodieFam_Back.DTOs;
using FoodieFam_Back.Models;
using FoodieFam_Back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserIngredientController : ControllerBase
    {
        private UserIngredientService _userIngredientService;

        public UserIngredientController(UserIngredientService userIngredientService)
        {
            _userIngredientService = userIngredientService;
        }

        [HttpPost]
        public async Task<ActionResult<UserIngredient>> AddUserIngredient(UserIngredientInsertDto userIngredientInsertDto)
        {
            var userIngredientDto = await _userIngredientService.Add(userIngredientInsertDto);
            return CreatedAtAction(nameof(GetByUserId), new {id = userIngredientDto.UserId}, userIngredientDto);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UserIngredientDto>> GetByUserId(Guid id) =>
            await _userIngredientService.GetByUserId(id);

        
    }
}
