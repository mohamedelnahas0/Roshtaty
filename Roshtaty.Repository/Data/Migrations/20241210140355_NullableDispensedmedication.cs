using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roshtaty.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullableDispensedmedication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Active_Ingredients_Active_IngredientId",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<string>(
                name: "Dispensedmedication",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Active_Ingredients_Active_IngredientId",
                table: "Prescriptions",
                column: "Active_IngredientId",
                principalTable: "Active_Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Active_Ingredients_Active_IngredientId",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<string>(
                name: "Dispensedmedication",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Active_Ingredients_Active_IngredientId",
                table: "Prescriptions",
                column: "Active_IngredientId",
                principalTable: "Active_Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
