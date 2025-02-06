using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roshtaty.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Active_Ingredients_Diseases_DiseaseId",
                table: "Active_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_categories_CategoryId",
                table: "Diseases");

            migrationBuilder.DropForeignKey(
                name: "FK_tradeNames_Active_Ingredients_Active_IngredientId",
                table: "tradeNames");

            migrationBuilder.AddForeignKey(
                name: "FK_Active_Ingredients_Diseases_DiseaseId",
                table: "Active_Ingredients",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_categories_CategoryId",
                table: "Diseases",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tradeNames_Active_Ingredients_Active_IngredientId",
                table: "tradeNames",
                column: "Active_IngredientId",
                principalTable: "Active_Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Active_Ingredients_Diseases_DiseaseId",
                table: "Active_Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_categories_CategoryId",
                table: "Diseases");

            migrationBuilder.DropForeignKey(
                name: "FK_tradeNames_Active_Ingredients_Active_IngredientId",
                table: "tradeNames");

            migrationBuilder.AddForeignKey(
                name: "FK_Active_Ingredients_Diseases_DiseaseId",
                table: "Active_Ingredients",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_categories_CategoryId",
                table: "Diseases",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tradeNames_Active_Ingredients_Active_IngredientId",
                table: "tradeNames",
                column: "Active_IngredientId",
                principalTable: "Active_Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
