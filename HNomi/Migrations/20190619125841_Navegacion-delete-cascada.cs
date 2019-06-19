using Microsoft.EntityFrameworkCore.Migrations;

namespace HNomi.Migrations
{
    public partial class Navegaciondeletecascada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesTipoNomina_TiposNomina_NominaId",
                table: "DetallesTipoNomina");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesTipoNomina_TiposNomina_NominaId",
                table: "DetallesTipoNomina",
                column: "NominaId",
                principalTable: "TiposNomina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesTipoNomina_TiposNomina_NominaId",
                table: "DetallesTipoNomina");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesTipoNomina_TiposNomina_NominaId",
                table: "DetallesTipoNomina",
                column: "NominaId",
                principalTable: "TiposNomina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
