using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api1.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Majas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numurs = table.Column<int>(type: "INTEGER", nullable: true),
                    Iela = table.Column<string>(type: "TEXT", nullable: true),
                    Pilseta = table.Column<string>(type: "TEXT", nullable: true),
                    Valsts = table.Column<string>(type: "TEXT", nullable: true),
                    Pasta_Indekss = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dzivokli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numurs = table.Column<int>(type: "INTEGER", nullable: true),
                    Stavs = table.Column<int>(type: "INTEGER", nullable: true),
                    Istabu_Skaits = table.Column<int>(type: "INTEGER", nullable: true),
                    Iedzivotaju_Skaits = table.Column<int>(type: "INTEGER", nullable: true),
                    Pilna_Platiba = table.Column<int>(type: "INTEGER", nullable: true),
                    Dzivojama_Platiba = table.Column<int>(type: "INTEGER", nullable: true),
                    Maja_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    MajaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzivokli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dzivokli_Majas_MajaId",
                        column: x => x.MajaId,
                        principalTable: "Majas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Iedzivotaji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vards = table.Column<string>(type: "TEXT", nullable: true),
                    Uzvards = table.Column<string>(type: "TEXT", nullable: true),
                    Personas_Kods = table.Column<long>(type: "INTEGER", nullable: true),
                    Dzimsanas_Datums = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Telefons = table.Column<long>(type: "INTEGER", nullable: true),
                    E_Mail = table.Column<string>(type: "TEXT", nullable: true),
                    Saikne_Ar_Dzivokli = table.Column<string>(type: "TEXT", nullable: true),
                    Is_Owner = table.Column<bool>(type: "INTEGER", nullable: true),
                    Dzivoklis_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    DzivoklisId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iedzivotaji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Iedzivotaji_Dzivokli_DzivoklisId",
                        column: x => x.DzivoklisId,
                        principalTable: "Dzivokli",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Majas_Dzivokli",
                columns: table => new
                {
                    Maja_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Dzivoklis_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majas_Dzivokli", x => new { x.Maja_Id, x.Dzivoklis_Id });
                    table.ForeignKey(
                        name: "FK_Majas_Dzivokli_Dzivokli_Dzivoklis_Id",
                        column: x => x.Dzivoklis_Id,
                        principalTable: "Dzivokli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Majas_Dzivokli_Majas_Maja_Id",
                        column: x => x.Maja_Id,
                        principalTable: "Majas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Iedzivotaju_Dzivokli",
                columns: table => new
                {
                    Iedzivotajs_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Dzivoklis_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Is_Owner = table.Column<bool>(type: "INTEGER", nullable: false),
                    Saikne_Ar_Dzivokli = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iedzivotaju_Dzivokli", x => new { x.Iedzivotajs_Id, x.Dzivoklis_Id });
                    table.ForeignKey(
                        name: "FK_Iedzivotaju_Dzivokli_Dzivokli_Dzivoklis_Id",
                        column: x => x.Dzivoklis_Id,
                        principalTable: "Dzivokli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Iedzivotaju_Dzivokli_Iedzivotaji_Iedzivotajs_Id",
                        column: x => x.Iedzivotajs_Id,
                        principalTable: "Iedzivotaji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dzivokli_MajaId",
                table: "Dzivokli",
                column: "MajaId");

            migrationBuilder.CreateIndex(
                name: "IX_Iedzivotaji_DzivoklisId",
                table: "Iedzivotaji",
                column: "DzivoklisId");

            migrationBuilder.CreateIndex(
                name: "IX_Iedzivotaju_Dzivokli_Dzivoklis_Id",
                table: "Iedzivotaju_Dzivokli",
                column: "Dzivoklis_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Majas_Dzivokli_Dzivoklis_Id",
                table: "Majas_Dzivokli",
                column: "Dzivoklis_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Iedzivotaju_Dzivokli");

            migrationBuilder.DropTable(
                name: "Majas_Dzivokli");

            migrationBuilder.DropTable(
                name: "Iedzivotaji");

            migrationBuilder.DropTable(
                name: "Dzivokli");

            migrationBuilder.DropTable(
                name: "Majas");
        }
    }
}
