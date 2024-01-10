namespace FoodieFam_Back.Models
{
    public class UserRecipe
    {
        public bool Favorite { get; set; }
        public Guid? UserId { get; set; }
        public Guid RecipeId { get; set; }
        public User User { get; set; }
        public Recipe Recipe { get; set; }

        //conexion usuario y recipes
    }
}
