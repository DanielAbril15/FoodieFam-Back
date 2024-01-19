using FoodieFam_Back.Models;

namespace FoodieFam_Back.DTOs
{
    public class UserIngredientInsertDto
    {
        public int Amount { get; set; }
        public Guid UserId { get; set; }
        public Guid IngredientId { get; set; }
    }
}
