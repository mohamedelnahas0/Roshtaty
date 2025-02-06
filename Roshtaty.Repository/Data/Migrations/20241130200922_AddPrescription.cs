using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roshtaty.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prescription_ID = table.Column<int>(type: "int", nullable: false),
                    ActiveIngridient_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Form = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Strength = table.Column<decimal>(type: "decimal(18,2)", maxLength: 100, nullable: false),
                    StrengthUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrescriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions");
        }
    }
}
