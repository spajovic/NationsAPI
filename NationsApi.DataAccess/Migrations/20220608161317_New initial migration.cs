using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationsApi.DataAccess.Migrations
{
    public partial class Newinitialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UseCaseLog_UseCaseName",
                table: "UseCaseLog");

            migrationBuilder.AlterColumn<string>(
                name: "UseCaseName",
                table: "UseCaseLog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UseCaseName",
                table: "UseCaseLog",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UseCaseLog_UseCaseName",
                table: "UseCaseLog",
                column: "UseCaseName",
                unique: true);
        }
    }
}
