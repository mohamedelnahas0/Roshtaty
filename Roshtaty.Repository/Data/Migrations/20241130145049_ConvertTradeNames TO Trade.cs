using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roshtaty.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertTradeNamesTOTrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tradeNames",
                newName: "TadeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "main_Systems",
                newName: "MainSystemName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Diseases",
                newName: "DiseaseName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Active_Ingredients",
                newName: "ActiveIngredientName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TadeName",
                table: "tradeNames",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MainSystemName",
                table: "main_Systems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DiseaseName",
                table: "Diseases",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ActiveIngredientName",
                table: "Active_Ingredients",
                newName: "Name");
        }
    }
}
