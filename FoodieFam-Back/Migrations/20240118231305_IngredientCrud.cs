using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodieFam_Back.Migrations
{
    /// <inheritdoc />
    public partial class IngredientCrud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIngredient_Ingredients_IngredientId",
                table: "UserIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIngredient_Users_UserId",
                table: "UserIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIngredient",
                table: "UserIngredient");

            migrationBuilder.RenameTable(
                name: "UserIngredient",
                newName: "UserIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_UserIngredient_IngredientId",
                table: "UserIngredients",
                newName: "IX_UserIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients",
                columns: new[] { "UserId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserIngredients_Ingredients_IngredientId",
                table: "UserIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIngredients_Users_UserId",
                table: "UserIngredients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIngredients_Ingredients_IngredientId",
                table: "UserIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIngredients_Users_UserId",
                table: "UserIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients");

            migrationBuilder.RenameTable(
                name: "UserIngredients",
                newName: "UserIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_UserIngredients_IngredientId",
                table: "UserIngredient",
                newName: "IX_UserIngredient_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIngredient",
                table: "UserIngredient",
                columns: new[] { "UserId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserIngredient_Ingredients_IngredientId",
                table: "UserIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIngredient_Users_UserId",
                table: "UserIngredient",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
