namespace FoodieFam_Back.Models
{
    public class RecipeIngredient
    {
        public int Amount { get; set; }

        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }

        public Recipe Recipe { get; set; }

        public Ingredient Ingredient { get; set; }

    }
}
