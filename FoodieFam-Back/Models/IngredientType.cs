namespace FoodieFam_Back.Models
{
    public class IngredientType
    {
        public int IngredientTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
