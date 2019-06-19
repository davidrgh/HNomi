using Microsoft.EntityFrameworkCore.Migrations;

namespace HNomi.Migrations
{
    public partial class Navegacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Impuestos_TiposNomina_NominaId",
                table: "Impuestos");

            migrationBuilder.AlterColumn<int>(
                name: "NominaId",
                table: "Impuestos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Impuestos_TiposNomina_NominaId",
                table: "Impuestos",
                column: "NominaId",
                principalTable: "TiposNomina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Impuestos_TiposNomina_NominaId",
                table: "Impuestos");

            migrationBuilder.AlterColumn<int>(
                name: "NominaId",
                table: "Impuestos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Impuestos_TiposNomina_NominaId",
                table: "Impuestos",
                column: "NominaId",
                principalTable: "TiposNomina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
