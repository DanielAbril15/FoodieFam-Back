using FoodieFam_Back.DTOs.IngredientTypeDto;
using FoodieFam_Back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientTypeController : ControllerBase
    {
        private ICommonIntService<IngredientTypeDto, IngredientTypeInsertDto, IngredientTypePutDto> _ingredientTypeService;
        public IngredientTypeController(
            [FromKeyedServices("ingredientTypeService")] ICommonIntService<IngredientTypeDto, IngredientTypeInsertDto, IngredientTypePutDto> ingredientTypeService
            )
        {
            _ingredientTypeService = ingredientTypeService;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientTypeDto>> GetAll() =>
            await _ingredientTypeService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientTypeDto>> GetTypeById(int id)
        {
            var ingredientTypeDto = await _ingredientTypeService.GetById(id);
            return ingredientTypeDto == null ? NotFound() : Ok(ingredientTypeDto);
        }

        [HttpPost]
        public async Task<ActionResult<IngredientTypeDto>> AddType(IngredientTypeInsertDto ingredientTypeInsertDto)
        {
            var ingredientTypeDto = await _ingredientTypeService.Add(ingredientTypeInsertDto);

            return CreatedAtAction(nameof(GetTypeById), new { id = ingredientTypeDto.IngredientTypeId }, ingredientTypeDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IngredientTypeDto>> UpdateType(int id, IngredientTypePutDto ingredientTypePutDto)
        {
            var ingredientTypeDto = await _ingredientTypeService.Update(id, ingredientTypePutDto);
            return ingredientTypeDto == null ? NotFound() : Ok(ingredientTypeDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IngredientTypeDto>> DeleteType(int id)
        {
            var ingredientType = await _ingredientTypeService.Delete(id);
            if (ingredientType==null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
