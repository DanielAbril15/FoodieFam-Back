namespace FoodieFam_Back.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<CategoryRecipe> CategoryRecipes { get; set; } 
    }
}
