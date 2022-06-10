using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationsApi.DataAccess.Migrations
{
    public partial class AddcolumnstoCountryStatsentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CountryStats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CountryStats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CountryStats",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CountryStats");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CountryStats");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CountryStats");
        }
    }
}
