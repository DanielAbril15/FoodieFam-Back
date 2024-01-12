using FoodieFam_Back.DTOs;
using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Services
{
    public class IngredientTypeService : ICommonIntService<IngredientTypeDto, IngredientTypeInsertDto, IngredientTypePutDto>
    {
        private IRepositoryInt<IngredientType> _ingredientTypeRepository;

        public IngredientTypeService(
            IRepositoryInt<IngredientType> ingredientTypeRepository
            )
        {
            _ingredientTypeRepository = ingredientTypeRepository;
        }

        public async Task<IEnumerable<IngredientTypeDto>> Get()
        {
            var ingredientTypes = await _ingredientTypeRepository.Get();
            return ingredientTypes.Select(type => new IngredientTypeDto
            {
                IngredientTypeId = type.IngredientTypeId,
                Name = type.Name
            });
        }

        public async Task<IngredientTypeDto> GetById(int id)
        {
            var ingredientType = await _ingredientTypeRepository.GetById(id);

            if (ingredientType != null)
            {
                var ingredientTypeDto = new IngredientTypeDto
                {
                    IngredientTypeId = ingredientType.IngredientTypeId,
                    Name = ingredientType.Name

                };
                return ingredientTypeDto;
            }
            return null;
        }

        public async Task<IngredientTypeDto> Add(IngredientTypeInsertDto ingredientTypeInsertDto)
        {
            var ingredientType = new IngredientType
            {
                Name = ingredientTypeInsertDto.Name,
            };

            await _ingredientTypeRepository.Add(ingredientType);
            await _ingredientTypeRepository.Save();

            var ingredientTypeDto = new IngredientTypeDto
            {
                IngredientTypeId = ingredientType.IngredientTypeId,
                Name = ingredientType.Name
            };
            return ingredientTypeDto;
        }

        public async Task<IngredientTypeDto> Update(int id, IngredientTypePutDto ingredientTypePutDto)
        {
            var ingredientType = await _ingredientTypeRepository.GetById(id);

            if (ingredientType != null)
            {
                ingredientType.Name = ingredientTypePutDto.Name;

                _ingredientTypeRepository.Update(ingredientType);
                await _ingredientTypeRepository.Save();

                var ingredientTypeDto = new IngredientTypeDto
                {
                    IngredientTypeId = ingredientType.IngredientTypeId,
                    Name = ingredientType.Name
                };
                return ingredientTypeDto;
            }
            return null;

        }

        public async Task<IngredientTypeDto> Delete(int id)
        {
            var ingredientType = await _ingredientTypeRepository.GetById(id);

            if(ingredientType != null)
            {
                var ingredientTypeDto = new IngredientTypeDto
                {
                    IngredientTypeId = ingredientType.IngredientTypeId,
                    Name = ingredientType.Name
                };
                
                _ingredientTypeRepository.Delete(ingredientType);
                await _ingredientTypeRepository.Save();
                
                return ingredientTypeDto;
            }
            return null;
        }
    }
}
