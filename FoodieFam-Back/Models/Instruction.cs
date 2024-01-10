namespace FoodieFam_Back.Models
{
    public class Instruction
    {
        public Guid InstructionId { get; set; }
        public string Description { get; set; }
        public int Step { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
