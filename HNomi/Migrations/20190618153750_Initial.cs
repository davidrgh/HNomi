using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HNomi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposNomina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Nocturnidad = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposNomina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetallesTipoNomina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    TieneRetencion = table.Column<bool>(nullable: false, defaultValue: false),
                    EsPorUnidad = table.Column<bool>(nullable: false, defaultValue: true),
                    Precio = table.Column<double>(nullable: false),
                    NominaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesTipoNomina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesTipoNomina_TiposNomina_NominaId",
                        column: x => x.NominaId,
                        principalTable: "TiposNomina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesTipoNomina_NominaId",
                table: "DetallesTipoNomina",
                column: "NominaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesTipoNomina");

            migrationBuilder.DropTable(
                name: "TiposNomina");
        }
    }
}
