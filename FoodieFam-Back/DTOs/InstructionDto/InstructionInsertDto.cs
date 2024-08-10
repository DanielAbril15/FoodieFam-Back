namespace FoodieFam_Back.DTOs.InstructionDto
{
    public class InstructionInsertDto
    {
        public string Description { get; set; }
        public int Step { get; set; }
        public Guid RecipeId { get; set; }
    }
}
