using FoodieFam_Back.Models;

namespace FoodieFam_Back.DTOs
{
    public class UserIngredientDto
    {
        public int Amount { get; set; }
        public string IngredientName { get; set; }
        public Guid UserId { get; set; }
        public Guid IngredientId { get; set; }
      
    }
}
