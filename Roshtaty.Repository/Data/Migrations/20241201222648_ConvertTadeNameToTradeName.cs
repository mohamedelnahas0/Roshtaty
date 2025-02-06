using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roshtaty.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertTadeNameToTradeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TadeName",
                table: "tradeNames",
                newName: "TradeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TradeName",
                table: "tradeNames",
                newName: "TadeName");
        }
    }
}
