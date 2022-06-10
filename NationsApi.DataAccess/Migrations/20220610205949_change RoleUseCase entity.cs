using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationsApi.DataAccess.Migrations
{
    public partial class changeRoleUseCaseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "RoleUseCases",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "RoleUseCases");
        }
    }
}
