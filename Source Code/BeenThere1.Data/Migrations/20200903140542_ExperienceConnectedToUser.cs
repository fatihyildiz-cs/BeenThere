using Microsoft.EntityFrameworkCore.Migrations;

namespace BeenThere1.Data.Migrations
{
    public partial class ExperienceConnectedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeenThereUserId",
                table: "Experiences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_BeenThereUserId",
                table: "Experiences",
                column: "BeenThereUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_AspNetUsers_BeenThereUserId",
                table: "Experiences",
                column: "BeenThereUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_AspNetUsers_BeenThereUserId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_BeenThereUserId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "BeenThereUserId",
                table: "Experiences");
        }
    }
}
