namespace FoodieFam_Back.Models
{
    public class Recipe
    {

        public Guid RecipeId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int Time { get; set; }
        public int Portions { get; set; }

        public int Likes { get; set; }

        public Guid? UserId { get; set; }

        public virtual User User { get; set; }

        public ICollection<Instruction> Instructions { get; set; }
        public ICollection<CategoryRecipe> CategoryRecipes { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public ICollection<UserRecipe> UserRecipes { get; set; }
    }
}
