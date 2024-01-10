namespace FoodieFam_Back.Models
{
    public class UserIngredient
    {
        public int Amount { get; set; }
        public Guid UserId { get; set; }
        public Guid IngredientId { get; set; }
        public User User { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
