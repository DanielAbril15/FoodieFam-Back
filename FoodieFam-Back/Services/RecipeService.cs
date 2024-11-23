using FoodieFam_Back.DTOs.CategoryDto;
using FoodieFam_Back.DTOs.RecipeDto;
using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;

namespace FoodieFam_Back.Services
{
    public class RecipeService 
    {
        private RecipeRepository _recipeRepository;
        public RecipeService(
            RecipeRepository recipeRepository
           )
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<RecipeDto> Add(RecipeInsertDto recipeInsertDto)
        {
            var recipe = new Recipe
            {
                Name = recipeInsertDto.Name,
                Description = recipeInsertDto.Description,
                Img = recipeInsertDto.Img,
                Time = recipeInsertDto.Time,
                Portions = recipeInsertDto.Portions,
                Likes = recipeInsertDto.Likes,
                UserId = recipeInsertDto.UserId,
            };
            await _recipeRepository.AddRecipe(recipe);
            await _recipeRepository.Save();

            var recipeDto = new RecipeDto
            {
                RecipeId = recipe.RecipeId,
                Name = recipeInsertDto.Name,
                Description = recipeInsertDto.Description,
                Img = recipeInsertDto.Img,
                Time = recipeInsertDto.Time,
                Portions= recipeInsertDto.Portions,
                Likes= recipeInsertDto.Likes,
                UserId = recipeInsertDto.UserId,
            };
            return recipeDto;
        }

        public async Task<RecipeDto> Delete(Guid id)
        {
            var recipe = await _recipeRepository.GetRecipeById(id);

            if (recipe != null)
            {
                var recipeDto = new RecipeDto
                {
                    RecipeId = recipe.RecipeId,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Img = recipe.Img,
                    Time = recipe.Time,
                    Portions= recipe.Portions,
                    Likes= recipe.Likes,
                    UserId = recipe.UserId,
                };
                _recipeRepository.Delete(recipe);
                await _recipeRepository.Save();
                return recipeDto;
            }
            return null;
        }

        // DE MOMENTO NO SE USA
        public async Task<IEnumerable<RecipeDto>> Get()
        {
            var recipes = await _recipeRepository.GetAllREcipes();

            return recipes.Select(recipe => new RecipeDto {
                RecipeId=recipe.RecipeId,
                Name = recipe.Name,
                Description = recipe.Description,
                Img = recipe.Img,
                Time = recipe.Time,
                Portions= recipe.Portions,
                Likes= recipe.Likes,
                UserId= recipe.UserId
            });
        }

        public async Task<RecipeDto> GetById(Guid id)
        {
            var recipe = await _recipeRepository.GetRecipeById(id);
            if(recipe != null)
            {
                var recipeDto = new RecipeDto
                {
                    RecipeId = recipe.RecipeId,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Img = recipe.Img,
                    Time = recipe.Time,
                    Portions= recipe.Portions,
                    Likes= recipe.Likes,
                    UserId= recipe.UserId
                };
                return recipeDto;
            }
            return null;
        }

        public async Task<RecipeDto> Update(Guid id, RecipePutDto recipePutDto)
        {
            var recipe = await _recipeRepository.GetRecipeById(id);

            if (recipe != null)
            {
                recipe.Name = recipePutDto.Name;
                recipe.Description = recipePutDto.Description;
                recipe.Img = recipePutDto.Img;
                recipe.Time = recipePutDto.Time;
                recipe.Portions = recipePutDto.Portions;
                recipe.Likes = recipePutDto.Likes;
               
                _recipeRepository.UpdateRecipe(recipe);
                await _recipeRepository.Save();

                var recipeDto = new RecipeDto
                {
                    RecipeId = recipe.RecipeId,
                    Name = recipePutDto.Name,
                    Description = recipePutDto.Description,
                    Img = recipePutDto.Img,
                    Time = recipePutDto.Time,
                    Portions = recipePutDto.Portions,
                    Likes = recipePutDto.Likes,
                    UserId= recipe.UserId,
                };
                return recipeDto;
            }
            return null;
        }
    }
}
