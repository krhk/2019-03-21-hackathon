using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon2.Data.Migrations
{
    public partial class @string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "Pharmacies",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PostCode",
                table: "Pharmacies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
