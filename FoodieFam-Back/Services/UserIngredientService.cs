using FoodieFam_Back.DTOs.UserIngredientDto;
using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Services
{
    public class UserIngredientService
    {
        private UserIngredientRepository _userIngredientRepository;
        private IngredientRepository _ingredientRepository;
        public UserIngredientService(UserIngredientRepository userIngredientrepository, IngredientRepository ingredientRepository)
        {
            _userIngredientRepository = userIngredientrepository;
            _ingredientRepository = ingredientRepository;
        }


        public async Task<IEnumerable<UserIngredientDto>> GetByUserId(Guid id)
        {
            var userIngredient = await _userIngredientRepository.GetByUserId(id);
            List<UserIngredientDto> userIngredientList = new List<UserIngredientDto>();

            foreach (var ui in userIngredient)
            {
                var ingredient = await _ingredientRepository.GetById(ui.IngredientId);
                userIngredientList.Add(
                new UserIngredientDto
                {
                    Amount = ui.Amount,
                    IngredientName = ingredient.Name,
                });
            }
            return userIngredientList;

        }

        public async Task<UserIngredientDto> Add(UserIngredientInsertDto userIngredientInsertDto)
        {
            var userIngredient = new UserIngredient
            {
                Amount = userIngredientInsertDto.Amount,
                UserId = userIngredientInsertDto.UserId,
                IngredientId = userIngredientInsertDto.IngredientId,

            };

            await _userIngredientRepository.Add(userIngredient);
            await _userIngredientRepository.Save();

            var userIngredientDto = new UserIngredientDto
            {
                Amount = userIngredient.Amount,
                UserId = userIngredient.UserId,
                IngredientId = userIngredient.IngredientId,
            };
            return userIngredientDto;

        }

    }
}
