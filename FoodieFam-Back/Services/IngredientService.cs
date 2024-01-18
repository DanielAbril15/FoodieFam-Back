using FoodieFam_Back.DTOs;
using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;

namespace FoodieFam_Back.Services
{
    public class IngredientService : ICommonGuidService<IngredientDto, IngredientInsertDto, IngredientPutDto>
    {
        private IngredientRepository _ingredientRepository;
        public IngredientService(
            IngredientRepository ingredientRepository
            )
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IEnumerable<IngredientDto>> Get()
        {
            var ingredients = await _ingredientRepository.Get();

            return ingredients.Select(ingredient => new IngredientDto
            {
                IngredientId = ingredient.IngredientId,
                Name = ingredient.Name,
                Img = ingredient.Img,
                IngredientTypeId = ingredient.IngredientTypeId,
            });
        }

        public async Task<IngredientDto> GetById(Guid id)
        {
            var ingredient = await _ingredientRepository.GetById(id);
            if (ingredient != null)
            {
                var ingredientDto = new IngredientDto
                {
                    IngredientId = ingredient.IngredientId,
                    Name = ingredient.Name,
                    Img = ingredient.Img,
                    IngredientTypeId = ingredient.IngredientTypeId,
                };
                return ingredientDto;
            }
            return null;
        }

        public async Task<IngredientDto> Add(IngredientInsertDto ingredientInsertDto)
        {
            var ingredient = new Ingredient
            {
                Name = ingredientInsertDto.Name,
                Img = ingredientInsertDto.Img,
                IngredientTypeId = ingredientInsertDto.IngredientTypeId,
            };

            await _ingredientRepository.Add(ingredient);

            await _ingredientRepository.Save();

            var ingredientDto = new IngredientDto
            {
                IngredientId = ingredient.IngredientId,
                Name = ingredient.Name,
                Img = ingredient.Img,
                IngredientTypeId = ingredient.IngredientTypeId
            };
            return ingredientDto;
        }

        public async Task<UserIngredientDto> AddUserIngredient(Guid userId, Guid ingredientId, UserIngredientInsertDto userIngredientInsertDto)
        {
            var userIngredient = new UserIngredient
            {
                Amount = userIngredientInsertDto.Amount,
                UserId = userId,
                IngredientId = ingredientId,
            };

            await _ingredientRepository.AddUserIngredient(userIngredient);

            await _ingredientRepository.Save();

            var userIngredientDto = new UserIngredientDto
            {
                Amount = userIngredient.Amount,
                UserId = userIngredient.UserId,
                IngredientId = userIngredient.IngredientId
            };
            return userIngredientDto;
        }

        public async Task<IngredientDto> Update(Guid id, IngredientPutDto ingredientPutDto)
        {
            var ingredient = await _ingredientRepository.GetById(id);

            if (ingredient != null)
            {
                ingredient.Name = ingredientPutDto.Name;
                ingredient.Img = ingredientPutDto.Img;
                ingredient.IngredientTypeId = ingredientPutDto.IngredientTypeId;

                _ingredientRepository.Update(ingredient);
                await _ingredientRepository.Save();

                var ingredientDto = new IngredientDto
                {
                    IngredientId = ingredient.IngredientId,
                    Name = ingredient.Name,
                    Img = ingredient.Img,
                    IngredientTypeId = ingredient.IngredientTypeId

                };
                return ingredientDto;
            }
            return null;
        }

        public async Task<IngredientDto> Delete(Guid id)
        {
            var ingredient = await _ingredientRepository.GetById(id);
            if (ingredient != null)
            {
                var ingredientDto = new IngredientDto
                {
                    IngredientId = ingredient.IngredientId,
                    Name = ingredient.Name,
                    Img = ingredient.Img,
                    IngredientTypeId = ingredient.IngredientTypeId
                };
                _ingredientRepository.Delete(ingredient);
                await _ingredientRepository.Save();
                return ingredientDto;
            }
            return null;

        }
    }
}
