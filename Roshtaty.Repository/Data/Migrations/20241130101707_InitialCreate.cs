using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roshtaty.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "main_Systems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_main_Systems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainSystemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categories_main_Systems_MainSystemId",
                        column: x => x.MainSystemId,
                        principalTable: "main_Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diseases_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Active_Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StrengthUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Active_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Active_Ingredients_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tradeNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Indication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShelfLife = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StorageConditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufactureCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PharmaceuticalForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministrationRoute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistributeArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active_IngredientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tradeNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tradeNames_Active_Ingredients_Active_IngredientId",
                        column: x => x.Active_IngredientId,
                        principalTable: "Active_Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Active_Ingredients_DiseaseId",
                table: "Active_Ingredients",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_MainSystemId",
                table: "categories",
                column: "MainSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_CategoryId",
                table: "Diseases",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tradeNames_Active_IngredientId",
                table: "tradeNames",
                column: "Active_IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tradeNames");

            migrationBuilder.DropTable(
                name: "Active_Ingredients");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "main_Systems");
        }
    }
}
