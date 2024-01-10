using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodieFam_Back.Migrations
{
    /// <inheritdoc />
    public partial class IngredientRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "Instructions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_RecipeId",
                table: "Instructions",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Recipes_RecipeId",
                table: "Instructions",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Recipes_RecipeId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_RecipeId",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Instructions");
        }
    }
}
