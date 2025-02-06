using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roshtaty.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrescriptionFKActiveId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "StrengthUnit",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "ActiveIngridient_Name",
                table: "Prescriptions",
                newName: "Dispensedmedication");

            migrationBuilder.AddColumn<int>(
                name: "Active_IngredientId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_Active_IngredientId",
                table: "Prescriptions",
                column: "Active_IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Active_Ingredients_Active_IngredientId",
                table: "Prescriptions",
                column: "Active_IngredientId",
                principalTable: "Active_Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Active_Ingredients_Active_IngredientId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_Active_IngredientId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Active_IngredientId",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "Dispensedmedication",
                table: "Prescriptions",
                newName: "ActiveIngridient_Name");

            migrationBuilder.AddColumn<decimal>(
                name: "Strength",
                table: "Prescriptions",
                type: "decimal(18,2)",
                maxLength: 100,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "StrengthUnit",
                table: "Prescriptions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
