namespace FoodieFam_Back.Models
{
    public class Ingredient
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int IngredientTypeId { get; set; }
        public IngredientType IngredientType { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public ICollection<UserIngredient> UserIngredients { get; set; }
    }
}
