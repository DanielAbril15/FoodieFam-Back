namespace FoodieFam_Back.Models
{
    public class CategoryRecipe
    {
        public int CategoryId { get; set; }
        public Guid RecipeId { get; set; }
        public Category Category { get; set; }
        public Recipe Recipe { get; set; }
    }
}
