using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week6_Esercitazione.Migrations
{
    public partial class PrimaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodiceFiscale = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodiceFiscale);
                });

            migrationBuilder.CreateTable(
                name: "Polizza",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataStipula = table.Column<DateTime>(type: "datetime", nullable: false),
                    ImportoAssicurato = table.Column<double>(type: "float", nullable: false),
                    RataMensile = table.Column<double>(type: "float", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    Tipopolizza = table.Column<string>(name: "Tipo polizza", type: "nvarchar(max)", nullable: false),
                    PercentualeCoperta = table.Column<int>(type: "int", nullable: true),
                    Targa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cilindrata = table.Column<int>(type: "int", nullable: true),
                    AnniAssicurato = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizza", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_Polizza_Cliente_CodiceFiscale",
                        column: x => x.CodiceFiscale,
                        principalTable: "Cliente",
                        principalColumn: "CodiceFiscale",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polizza_CodiceFiscale",
                table: "Polizza",
                column: "CodiceFiscale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polizza");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
