using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Models
{
    public class FoodieFamContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserIngredient> UserIngredients { get; set; }
        public DbSet<CategoryRecipe> CategoryRecipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }



        public FoodieFamContext(DbContextOptions<FoodieFamContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(p => p.UserId);
                user.Property(p => p.Name).IsRequired().HasMaxLength(150);
                user.Property(p => p.LastName).IsRequired().HasMaxLength(150);
                user.Property(p => p.Email).IsRequired();
                user.Property(p => p.Password).IsRequired();
                user.Property(p => p.Role).HasDefaultValue("normal");
                user.Property(p => p.Status).HasDefaultValue(true);
                user.Property(p => p.IsVerified).HasDefaultValue(false);
                user.Property(p => p.DateCreated).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<IngredientType>(type =>
            {
                type.HasKey(p => p.IngredientTypeId);
                type.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<Ingredient>(ingredient =>
            {
                ingredient.HasKey(p => p.IngredientId);
                ingredient.Property(p => p.Name).IsRequired();
                ingredient.Property(p => p.Img).IsRequired();
                ingredient.HasOne(p => p.IngredientType).WithMany(p => p.Ingredients).HasForeignKey(p => p.IngredientTypeId);
            });

            modelBuilder.Entity<Category>(category =>
            {
                category.HasKey(p => p.CategoryId);
                category.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<Recipe>(recipe =>
            {
                recipe.HasKey(p => p.RecipeId);
                recipe.Property(p => p.Name).IsRequired();
                recipe.Property(p => p.Description);
                recipe.Property(p => p.Img).IsRequired();
                recipe.Property(p => p.Time).IsRequired();
                recipe.Property(p => p.Portions).IsRequired();
                recipe.Property(p => p.Likes).HasDefaultValue(0);
                recipe.HasOne(p => p.User).WithMany(p => p.Recipes).HasForeignKey(p => p.UserId);

            });

            modelBuilder.Entity<CategoryRecipe>(cr =>
            {
                cr.HasKey(p => new { p.CategoryId, p.RecipeId });
                cr.HasOne(p => p.Category).WithMany(p => p.CategoryRecipes).HasForeignKey(p => p.CategoryId);
                cr.HasOne(p => p.Recipe).WithMany(p => p.CategoryRecipes).HasForeignKey(p => p.RecipeId);
            });

            modelBuilder.Entity<RecipeIngredient>(ri =>
            {
                ri.HasKey(p => new { p.RecipeId, p.IngredientId });
                ri.HasOne(p => p.Recipe).WithMany(p => p.RecipeIngredients).HasForeignKey(p => p.RecipeId);
                ri.HasOne(p => p.Ingredient).WithMany(p => p.RecipeIngredients).HasForeignKey(p => p.IngredientId);
            });

            modelBuilder.Entity<UserIngredient>(ui =>
            {
                ui.HasKey(p => new { p.UserId, p.IngredientId });
                ui.HasOne(p => p.User).WithMany(p => p.UserIngredients).HasForeignKey(p => p.UserId);
                ui.HasOne(p => p.Ingredient).WithMany(p => p.UserIngredients).HasForeignKey(p => p.IngredientId);
            });

            modelBuilder.Entity<UserRecipe>(ur =>
            {
                ur.HasKey(p => new { p.UserId, p.RecipeId });
                ur.HasOne(p => p.User).WithMany(p => p.UserRecipes).HasForeignKey(p => p.UserId);
                ur.HasOne(p => p.Recipe).WithMany(p => p.UserRecipes).HasForeignKey(p => p.RecipeId);
            });

            modelBuilder.Entity<Instruction>(instruction =>
            {
                instruction.HasKey(p => p.InstructionId);
                instruction.Property(p => p.Description).IsRequired();
                instruction.Property(p => p.Step).IsRequired();
                instruction.HasOne(p => p.Recipe).WithMany(p => p.Instructions).HasForeignKey(p => p.RecipeId);
            });



        }
    }
}
