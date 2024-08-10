using FoodieFam_Back.DTOs.InstructionDto;
using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;

namespace FoodieFam_Back.Services
{
    public class InstructionService : ICommonGuidService<InstructionDto, InstructionInsertDto, InstructionPutDto>
    {
        private IRepositoryGuid<Instruction> _instructionRepository;

        public InstructionService(IRepositoryGuid<Instruction> instructionRepository)
        {
            _instructionRepository = instructionRepository;
        }

        public async Task<InstructionDto> Add(InstructionInsertDto instructionInsertDto)
        {
            var instruction = new Instruction
            {
                Description = instructionInsertDto.Description,
                Step = instructionInsertDto.Step,
                RecipeId = instructionInsertDto.RecipeId,
            };
            await _instructionRepository.Add(instruction);
            await _instructionRepository.Save();

            var instructionDto = new InstructionDto
            {
                InstructionId = instruction.InstructionId,
                Description = instruction.Description,
                Step = instruction.Step,
                RecipeId = instruction.RecipeId,
                Recipe = instruction.Recipe
            };
            return instructionDto;
        }

        public async Task<InstructionDto> Delete(Guid id)
        {
            var instruction = await _instructionRepository.GetById(id);
            if (instruction != null) 
            {
                var instructionDto = new InstructionDto
                {
                    InstructionId = instruction.InstructionId,
                    Description = instruction.Description,
                    Step = instruction.Step,
                    RecipeId = instruction.RecipeId,
                };
                _instructionRepository.Delete(instruction);
                await _instructionRepository.Save();
                return instructionDto;
            }
            return null;
        }

        public async Task<IEnumerable<InstructionDto>> Get()
        {
            var instructions = await _instructionRepository.Get();
            return instructions.Select(instruction => new InstructionDto
            {
                InstructionId = instruction.InstructionId,
                Description = instruction.Description,
                Step = instruction.Step,
                RecipeId = instruction.RecipeId,
                Recipe = instruction.Recipe
            });
        }

        public async Task<InstructionDto> GetById(Guid id)
        {
            var instruction = await _instructionRepository.GetById(id);
            if ( instruction != null)
            {
                var instructionDto = new InstructionDto
                {
                    InstructionId = instruction.InstructionId,
                    Description = instruction.Description,
                    Step = instruction.Step,
                    RecipeId = instruction.RecipeId,
                    Recipe = instruction.Recipe,
                };
                return instructionDto;
            }
            return null;
        }

        public async Task<InstructionDto> Update(Guid id, InstructionPutDto instructionPutDto)
        {
            var instruction = await _instructionRepository.GetById(id);
            if (instruction != null) 
            {
                instruction.Description = instructionPutDto.Description;
                instruction.Step = instructionPutDto.Step;

                _instructionRepository.Update(instruction);
                await _instructionRepository.Save();

                var istructionDto = new InstructionDto
                {
                    InstructionId = instruction.InstructionId,
                    Description = instruction.Description,
                    Step = instruction.Step,
                    RecipeId = instruction.RecipeId,
                    Recipe = instruction.Recipe,
                };
                return istructionDto;
            }
            return null;
        }
    }
}
