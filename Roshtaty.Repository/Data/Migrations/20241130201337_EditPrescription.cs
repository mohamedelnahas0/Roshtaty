using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roshtaty.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prescription_ID",
                table: "Prescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prescription_ID",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
