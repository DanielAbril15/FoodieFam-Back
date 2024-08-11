using FoodieFam_Back.DTOs.InstructionDto;
using FoodieFam_Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodieFam_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionController: ControllerBase
    {
        private InstructionService _instructionService;

        public InstructionController(InstructionService instructionService)
        {
            _instructionService = instructionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructionDto>> GetInstructionById(Guid id) 
        {
            var instructionDto = await _instructionService.GetById(id);
            return instructionDto == null ? NotFound() : Ok(instructionDto);
        }

        [HttpPost]
        public async Task<ActionResult<InstructionDto>> AddInstruction(InstructionInsertDto instructionInsertDto)
        {
            var instructionDto = await _instructionService.Add(instructionInsertDto);
            return CreatedAtAction(nameof(GetInstructionById), new { id = instructionDto.InstructionId}, instructionDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InstructionDto>> UpdateInstruction(Guid id, InstructionPutDto instructionPutDto) 
        {
            var instructionDto = await _instructionService.Update(id, instructionPutDto);
            return instructionDto == null? NotFound() : Ok(instructionDto);
        }

        [HttpDelete]
        public async Task<ActionResult<InstructionDto>> DeleteInstruction (Guid id)
        {
            var instruction = await _instructionService.Delete(id);
            return NoContent();
        }
        
    }
}
