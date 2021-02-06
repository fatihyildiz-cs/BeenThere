using Microsoft.EntityFrameworkCore.Migrations;

namespace BeenThere1.Data.Migrations
{
    public partial class ExperienceCategoryJunctionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExperienceCategoryJunction",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceCategoryJunction", x => new { x.ExperienceId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ExperienceCategoryJunction_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceCategoryJunction_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceCategoryJunction_CategoryId",
                table: "ExperienceCategoryJunction",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceCategoryJunction");
        }
    }
}
