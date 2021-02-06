using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeenThere1.WebUI.Migrations
{
    public partial class FewPropertiesAddedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentCountry",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CurrentlyTraveling",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InstagramId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalWebsite",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCountry",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentlyTraveling",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InstagramId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonalWebsite",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "YoutubeId",
                table: "AspNetUsers");
        }
    }
}
