using FoodieFam_Back.DTOs.IngredientDto;
using FoodieFam_Back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IngredientService _ingredientService;

        public IngredientController(
            IngredientService ingredientService
            )
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientDto>> GetIngredients() =>
            await _ingredientService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDto>> GetIngredientById(Guid id)
        {
            var ingredientDto = await _ingredientService.GetById(id);
            return ingredientDto == null ? NotFound() : Ok(ingredientDto);
        }

        [HttpPost]

        public async Task<ActionResult<IngredientDto>> AddIngredient(IngredientInsertDto ingredientInsertDto)
        {
            var ingredientDto = await _ingredientService.Add(ingredientInsertDto);
            return CreatedAtAction(nameof(GetIngredientById), new { id = ingredientDto.IngredientId }, ingredientDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IngredientDto>> UpdateIngredient(Guid id, IngredientPutDto ingredientPutDto)
        {
            var ingredientDto = await _ingredientService.Update(id, ingredientPutDto);

            return ingredientDto == null ? NotFound() : Ok(ingredientDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IngredientDto>> DeleteIngredient(Guid id)
        {
            var ingredient = await _ingredientService.Delete(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
