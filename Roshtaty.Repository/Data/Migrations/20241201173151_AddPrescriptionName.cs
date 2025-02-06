using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roshtaty.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPrescriptionName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prescription_Name",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prescription_Name",
                table: "Prescriptions");
        }
    }
}
