using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hackathon.Data.Migrations
{
    public partial class trk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.CreateTable(
                name: "Hasici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    KodOkresu = table.Column<string>(nullable: true),
                    NazevOkresu = table.Column<string>(nullable: true),
                    DruhPracoviste = table.Column<string>(nullable: true),
                    TypStanice = table.Column<string>(nullable: true),
                    Ulice = table.Column<string>(nullable: true),
                    CisloPopisne = table.Column<string>(nullable: true),
                    Mesto = table.Column<string>(nullable: true),
                    PSC = table.Column<string>(nullable: true),
                    WKT = table.Column<string>(nullable: true),
                    GPS = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hasici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaslednaPece",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Poskytovatel = table.Column<string>(nullable: true),
                    PravniForma = table.Column<string>(nullable: true),
                    KodObce = table.Column<string>(nullable: true),
                    NazevObce = table.Column<string>(nullable: true),
                    Ulice = table.Column<string>(nullable: true),
                    CiscloPopisne = table.Column<string>(nullable: true),
                    PSC = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaslednaPece", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nemocnice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Typ = table.Column<string>(nullable: true),
                    Urceni = table.Column<string>(nullable: true),
                    KodOkresu = table.Column<string>(nullable: true),
                    NazevOkresu = table.Column<string>(nullable: true),
                    KodObce = table.Column<string>(nullable: true),
                    NazevObce = table.Column<string>(nullable: true),
                    NazevPoskytovatele = table.Column<string>(nullable: true),
                    Ulice = table.Column<string>(nullable: true),
                    CiscloPopisne = table.Column<string>(nullable: true),
                    OrdinacniHodiny = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nemocnice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    KodOkresu = table.Column<string>(nullable: true),
                    NazevOkresu = table.Column<string>(nullable: true),
                    Obvod = table.Column<string>(nullable: true),
                    Ulice = table.Column<string>(nullable: true),
                    CisloPopisne = table.Column<string>(nullable: true),
                    Mesto = table.Column<string>(nullable: true),
                    PSC = table.Column<string>(nullable: true),
                    WKT = table.Column<string>(nullable: true),
                    GPS = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stomatologie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Oblast = table.Column<string>(nullable: true),
                    Datum = table.Column<string>(nullable: true),
                    JmenoLekare = table.Column<string>(nullable: true),
                    KodObce = table.Column<string>(nullable: true),
                    NazevObce = table.Column<string>(nullable: true),
                    Ulice = table.Column<string>(nullable: true),
                    CiscloPopisne = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    OrdinacniHodiny = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stomatologie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Update",
                columns: table => new
                {
                    Nazev = table.Column<string>(nullable: false),
                    DatumCas = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Update", x => x.Nazev);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hasici");

            migrationBuilder.DropTable(
                name: "NaslednaPece");

            migrationBuilder.DropTable(
                name: "Nemocnice");

            migrationBuilder.DropTable(
                name: "Policie");

            migrationBuilder.DropTable(
                name: "Stomatologie");

            migrationBuilder.DropTable(
                name: "Update");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUserClaims",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoleClaims",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");
        }
    }
}
