using FoodieFam_Back.Models;

namespace FoodieFam_Back.DTOs
{
    public class IngredientInsertDto
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public int IngredientTypeId { get; set; }
    }
}
