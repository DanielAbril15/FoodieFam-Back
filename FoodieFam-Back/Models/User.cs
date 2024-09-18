namespace FoodieFam_Back.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        public bool IsVerified { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<UserIngredient> UserIngredients { get; set; }
        public ICollection<UserRecipe> UserRecipes { get; set; }

    }
}
