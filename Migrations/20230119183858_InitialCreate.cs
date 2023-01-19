using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelefoaneOnline.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieProdus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Culoare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuloareProdus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culoare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Memorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemorieProdus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Telefon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagDisplay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: true),
                    MemorieID = table.Column<int>(type: "int", nullable: true),
                    CuloareID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Telefon_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Telefon_Culoare_CuloareID",
                        column: x => x.CuloareID,
                        principalTable: "Culoare",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Telefon_Memorie_MemorieID",
                        column: x => x.MemorieID,
                        principalTable: "Memorie",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cumparat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorID = table.Column<int>(type: "int", nullable: true),
                    TelefonID = table.Column<int>(type: "int", nullable: true),
                    DataAchizitie = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cumparat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cumparat_Telefon_TelefonID",
                        column: x => x.TelefonID,
                        principalTable: "Telefon",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cumparat_Utilizator_UtilizatorID",
                        column: x => x.UtilizatorID,
                        principalTable: "Utilizator",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MemorieInterna",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefonID = table.Column<int>(type: "int", nullable: false),
                    MemorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorieInterna", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MemorieInterna_Memorie_MemorieID",
                        column: x => x.MemorieID,
                        principalTable: "Memorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemorieInterna_Telefon_TelefonID",
                        column: x => x.TelefonID,
                        principalTable: "Telefon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cumparat_TelefonID",
                table: "Cumparat",
                column: "TelefonID");

            migrationBuilder.CreateIndex(
                name: "IX_Cumparat_UtilizatorID",
                table: "Cumparat",
                column: "UtilizatorID");

            migrationBuilder.CreateIndex(
                name: "IX_MemorieInterna_MemorieID",
                table: "MemorieInterna",
                column: "MemorieID");

            migrationBuilder.CreateIndex(
                name: "IX_MemorieInterna_TelefonID",
                table: "MemorieInterna",
                column: "TelefonID");

            migrationBuilder.CreateIndex(
                name: "IX_Telefon_CategorieID",
                table: "Telefon",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_Telefon_CuloareID",
                table: "Telefon",
                column: "CuloareID");

            migrationBuilder.CreateIndex(
                name: "IX_Telefon_MemorieID",
                table: "Telefon",
                column: "MemorieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cumparat");

            migrationBuilder.DropTable(
                name: "MemorieInterna");

            migrationBuilder.DropTable(
                name: "Utilizator");

            migrationBuilder.DropTable(
                name: "Telefon");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Culoare");

            migrationBuilder.DropTable(
                name: "Memorie");
        }
    }
}
