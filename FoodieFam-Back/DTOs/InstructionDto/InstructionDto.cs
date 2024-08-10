using FoodieFam_Back.Models;

namespace FoodieFam_Back.DTOs.InstructionDto
{
    public class InstructionDto
    {
        public Guid InstructionId { get; set; }
        public string Description { get; set; }
        public int Step { get; set; }
        public Guid RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
