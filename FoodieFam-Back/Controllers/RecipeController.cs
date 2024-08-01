using FoodieFam_Back.DTOs.CategoryDto;
using FoodieFam_Back.DTOs.RecipeDto;
using FoodieFam_Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private RecipeService _recipeService;

        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetRecipeById(Guid id)
        {
            var recipeDto = await _recipeService.GetById(id);
            return recipeDto == null ? NotFound() : Ok(recipeDto);
        }

        [HttpPost]
        public async Task<ActionResult<RecipeDto>> AddRecipe(RecipeInsertDto recipeInsertDto)
        {
            var recipeDto = await _recipeService.Add(recipeInsertDto);
            return CreatedAtAction(nameof(GetRecipeById), new {id = recipeDto.UserId},recipeDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RecipeDto>> UpdateCategory(Guid id, RecipePutDto recipePutDto)
        {
            var recipeDto = await _recipeService.Update(id, recipePutDto);

            return recipeDto == null ? NotFound() : Ok(recipeDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RecipeDto>> DeleteCategory(Guid id)
        {
            var recipe = await _recipeService.Delete(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
