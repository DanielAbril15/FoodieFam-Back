using FoodieFam_Back.Models;

namespace FoodieFam_Back.DTOs.IngredientDto
{
    public class IngredientDto
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int IngredientTypeId { get; set; }
    }
}
