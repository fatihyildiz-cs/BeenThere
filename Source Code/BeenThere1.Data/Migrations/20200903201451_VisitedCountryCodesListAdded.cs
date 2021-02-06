using Microsoft.EntityFrameworkCore.Migrations;

namespace BeenThere1.Data.Migrations
{
    public partial class VisitedCountryCodesListAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VisitedCountryCodesList",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryListId = table.Column<int>(nullable: false),
                    CountryName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_CountryLists_CountryListId",
                        column: x => x.CountryListId,
                        principalTable: "CountryLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_CountryListId",
                table: "Country",
                column: "CountryListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "CountryLists");

            migrationBuilder.DropColumn(
                name: "VisitedCountryCodesList",
                table: "AspNetUsers");
        }
    }
}
