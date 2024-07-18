using FoodieFam_Back.Models;

namespace FoodieFam_Back.DTOs.IngredientDto
{
    public class IngredientPutDto
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public int IngredientTypeId { get; set; }
    }
}
